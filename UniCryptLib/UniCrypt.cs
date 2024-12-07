using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace UniCryptLib
{
    public class UniCrypt
    {
        private const string TspUrlDefault = "http://acskidd.gov.ua/services/tsp";
        private const int TspTimeout = 5000;
        private static readonly Encoding encoding = Encoding.GetEncoding(1251);
        private static TUCLCTX_CheckKeyPair UCLCTX_CheckKeyPair;
        private static TUCLCTX_GetCertInfo UCLCTX_GetCertInfo;
        private static TUCLCTX_CreateContainer UCLCTX_CreateContainer;
        private static TUCLCTX_Verify UCLCTX_Verify;
        private static TUCLCTX_GetContainerInfos UCLCTX_GetContainerInfos;
        private static TUCLCTX_AddTimestamp UCLCTX_AddTimestamp;
        private static TUCLCTX_GetCertsFromPBContainer UCLCTX_GetCertsFromPBContainer;

        public static CertKeyPair CurrentCert { get; set; }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibrary(byte[] lpFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, byte[] procname);

        public static void Init(string dataDir) => InitFuncs();

        private static void InitFuncs()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string baseDir = Path.Combine(Path.GetDirectoryName(assembly.Location), "lib");
            string str = Path.Combine(baseDir, IntPtr.Size != 4 ? "x64" : "x86", "unicryptd.dll");
            IntPtr lib = LoadLibrary(encoding.GetBytes(str + "\0"));
            if (lib == IntPtr.Zero)
                throw new DllNotFoundException("Ошибка загрузки " + str);
            GetProc(lib, "UCLCTX_CheckKeyPair", out UCLCTX_CheckKeyPair);
            GetProc(lib, "UCLCTX_GetCertInfo", out UCLCTX_GetCertInfo);
            GetProc(lib, "UCLCTX_CreateContainer", out UCLCTX_CreateContainer);
            GetProc(lib, "UCLCTX_Verify", out UCLCTX_Verify);
            GetProc(lib, "UCLCTX_GetContainerInfos", out UCLCTX_GetContainerInfos);
            GetProc(lib, "UCLCTX_AddTimestamp", out UCLCTX_AddTimestamp);
            GetProc(lib, "UCLCTX_GetCertsFromPBContainer", out UCLCTX_GetCertsFromPBContainer);
        }

        private static void GetProc<T>(IntPtr lib, string name, out T r) where T : class
        {
            byte[] procname = name != null ? encoding.GetBytes(name + "\0") : null;
            IntPtr procAddress = GetProcAddress(lib, procname);
            if (procAddress == IntPtr.Zero)
                r = default(T);
            else
                r = Marshal.GetDelegateForFunctionPointer(procAddress, typeof(T)) as T;
        }

        public static int CheckKeyPair(byte[] cert, byte[] key, string password)
        {
            byte[] password1 = password != null ? encoding.GetBytes(password + "\0") : null;
            return UCLCTX_CheckKeyPair(cert, cert.Length, key, key.Length, password1);
        }

        public static int GetCertInfo(byte[] cert, out UAExtCertInfo info)
        {
            info = new UAExtCertInfo();
            return UCLCTX_GetCertInfo(cert, cert.Length, ref info);
        }

        public static int MakeFirstSign(
          byte[] data,
          byte[] cert,
          byte[] key,
          string password,
          out byte[] outData)
        {
            UACADESInfo additionalFields = new UACADESInfo();
            int containerLen = 0;
            outData = null;
            byte[] password1 = password != null ? encoding.GetBytes(password + "\0") : null;
            int num1 = UCLCTX_CreateContainer(data, data.Length, cert, cert.Length, key, key.Length, password1, null, ref containerLen, ref additionalFields);
            if (num1 != 0)
                return num1;
            outData = new byte[containerLen];
            int num2 = UCLCTX_CreateContainer(data, data.Length, cert, cert.Length, key, key.Length, password1, outData, ref containerLen, ref additionalFields);
            if (num2 != 0)
            {
                outData = null;
                return num2;
            }
            if (containerLen != outData.Length)
                Array.Resize(ref outData, containerLen);
            return num2;
        }

        public static int MakeFirstSign(
          byte[] data,
          CertKeyPair cert,
          bool setTimestamp,
          out byte[] outData)
        {
            byte[] outData1;
            int num1 = MakeFirstSign(data, cert.Cert, cert.Key, cert.Pass, out outData1);
            if (num1 != 0)
            {
                outData = null;
                return num1;
            }
            if (!setTimestamp)
            {
                outData = outData1;
                return 0;
            }
            int containerLen = outData1.Length + 10240;
            outData = new byte[containerLen];
            string str = cert.CertInfo.accessTimeStamping?.ToLower();
            if (string.IsNullOrWhiteSpace(str) || str.Contains(TspUrlDefault))
                str = TspUrlDefault;
            byte[] bytes = encoding.GetBytes(str + "\0");
            UATSInfo info = new UATSInfo();
            int wsaResponse;
            int num2 = UCLCTX_AddTimestamp(outData1, outData1.Length, 0, cert.Cert, cert.Cert.Length, outData, ref containerLen, ref info, out wsaResponse, bytes, 80, TspTimeout);
            if (num2 != 0 && str != TspUrlDefault)
                num2 = UCLCTX_AddTimestamp(outData1, outData1.Length, 0, cert.Cert, cert.Cert.Length, outData, ref containerLen, ref info, out wsaResponse, bytes, 80, TspTimeout);
            if (num2 != 0)
            {
                outData = outData1;
                return 0;
            }
            if (containerLen != outData.Length)
                Array.Resize(ref outData, containerLen);
            return 0;
        }

        public static int VerifySign(byte[] data, out byte[] content, out string signerSerialNumber)
        {
            content = null;
            signerSerialNumber = string.Empty;
            int signerCount = 10;
            int[] verifyResults = new int[signerCount];
            int num1 = UCLCTX_Verify(data, data.Length, verifyResults, ref signerCount);
            if (num1 != 0)
                return num1;
            for (int index = 0; index < signerCount; ++index)
            {
                if (VrToCryptError(verifyResults[index]) != CryptErrors.CRYPT_OK)
                    return (int)VrToCryptError(verifyResults[index]);
            }
            UARecord commonBuffer = new UARecord(data.Length);
            int num2 = UCLCTX_GetContainerInfos(data, data.Length, null, ref signerCount, ref commonBuffer);
            if (num2 != 0)
                return num2;
            UACADESInfo[] info = new UACADESInfo[signerCount];
            int num3 = UCLCTX_GetContainerInfos(data, data.Length, info, ref signerCount, ref commonBuffer);
            if (num3 != 0)
                return num3;
            for (int index = 0; index < signerCount; ++index)
            {
                UACADESInfo uacadesInfo = info[index];
                if (uacadesInfo.content.data != IntPtr.Zero && uacadesInfo.content.datalen != 0)
                {
                    uacadesInfo.content.data.ToInt64();
                    content = new byte[uacadesInfo.content.datalen];
                    Marshal.Copy(uacadesInfo.content.data, content, 0, content.Length);
                    signerSerialNumber = uacadesInfo.signerSerialNumber;
                    break;
                }
            }
            return 0;
        }

        public static int HasFail(int vr) => vr & 17476;

        public static int HasError(int vr) => vr & 34952;

        public static CryptErrors VrToCryptError(int vr)
        {
            int num1 = HasError(vr);
            if (num1 != 0)
            {
                if ((num1 & 8) != 0)
                    return CryptErrors.CRYPT_BAD_SIGN;
                if ((num1 & 128) != 0 || (num1 & 2048) != 0)
                    return CryptErrors.USC_TS_DIFHASH;
            }
            int num2 = HasFail(vr);
            if (num2 != 0)
            {
                if ((num2 & 4) != 0)
                    return CryptErrors.CRYPT_BAD_SIGN;
                if ((num2 & 64) != 0 || (num2 & 1024) != 0)
                    return CryptErrors.USC_TS_DIFHASH;
            }
            return CryptErrors.CRYPT_OK;
        }

        public static int GetCertsFromPBContainer(byte[] pbKey, out byte[][] certs, bool onlyUserCerts)
        {
            certs = null;
            int CertsCnt = 0;
            int num1 = UCLCTX_GetCertsFromPBContainer(pbKey, pbKey.Length, null, ref CertsCnt, onlyUserCerts ? 1 : 0);
            if (num1 != 0 || CertsCnt == 0)
                return num1;
            UARecord[] Certs = new UARecord[CertsCnt];
            int num2 = UCLCTX_GetCertsFromPBContainer(pbKey, pbKey.Length, Certs, ref CertsCnt, onlyUserCerts ? 1 : 0);
            if (num2 != 0)
                return num2;
            try
            {
                for (int index = 0; index < CertsCnt; ++index)
                {
                    if (Certs[index].datalen != 0)
                        Certs[index].data = Marshal.AllocHGlobal(Certs[index].datalen);
                }
                num2 = UCLCTX_GetCertsFromPBContainer(pbKey, pbKey.Length, Certs, ref CertsCnt, onlyUserCerts ? 1 : 0);
                if (num2 != 0)
                    return num2;
                certs = new byte[CertsCnt][];
                for (int index = 0; index < CertsCnt; ++index)
                {
                    if (Certs[index].datalen != 0)
                    {
                        certs[index] = new byte[Certs[index].datalen];
                        Marshal.Copy(Certs[index].data, certs[index], 0, Certs[index].datalen);
                    }
                }
            }
            finally
            {
                for (int index = 0; index < CertsCnt; ++index)
                {
                    if (Certs[index].datalen != 0 && Certs[index].data != IntPtr.Zero)
                        Marshal.FreeHGlobal(Certs[index].data);
                }
            }
            return num2;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        private delegate int TUCLD_InitF(
          byte[] pFlLst,
          StringBuilder pCSKNm,
          int pCSKNmSz,
          out UIntPtr pDLib,
          IntPtr pResLLib);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int TUCLCTX_CheckKeyPair(
          byte[] cert,
          int certLen,
          byte[] privateKey,
          int privateKeyLen,
          byte[] password);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int TUCLCTX_GetCertInfo(byte[] cert, int certLen, ref UAExtCertInfo info);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int TUCLCTX_CreateContainer(
          byte[] data,
          int dataLen,
          byte[] cert,
          int certLen,
          byte[] privateKey,
          int privateKeyLen,
          byte[] password,
          byte[] container,
          ref int containerLen,
          ref UACADESInfo additionalFields);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int TUCLCTX_Verify(
          byte[] container,
          int containerLen,
          int[] verifyResults,
          ref int signerCount);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int TUCLCTX_GetContainerInfos(
          byte[] container,
          int containerLen,
          [Out] UACADESInfo[] info,
          ref int signerCount,
          ref UARecord commonBuffer);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int TUCLCTX_AddTimestamp(
          byte[] origContainer,
          int origContainerLen,
          int signIndex,
          byte[] cert,
          int certLen,
          byte[] container,
          ref int containerLen,
          ref UATSInfo info,
          out int wsaResponse,
          byte[] host,
          int port,
          int timeout);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int TUCLCTX_GetCertsFromPBContainer(
          byte[] PBKey,
          int PBKeyLen,
          [In, Out] UARecord[] Certs,
          ref int CertsCnt,
          int bOnlyUserCerts);
    }
}
