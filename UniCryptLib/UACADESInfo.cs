using System;
using System.Runtime.InteropServices;
using System.Text;

namespace UniCryptLib
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UACADESInfo
    {
        private static readonly Encoding encoding = Encoding.GetEncoding(1251);
        public UARecord commonBuffer;
        public uint writeFields;
        public UIntPtr signingTime;
        public UARecord sigPolicy;
        public UARecord spURI;
        public UARecord spUserNotice;
        public UARecord contentTS;
        public UARecord content;
        public UARecord signerCert;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _signerCertHash;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _signerSerialNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _signerKeyId;
        public UASubjectInfo issuer;
        public UARecord signature;
        public UARecord signatureTS;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public UARecord[] certs;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public UARecord[] crls;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public UARecord[] ocsps;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public UACADESrefs[] chain_refs;

        public DateTime GetSigningTime
        {
            get
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
                dateTime = dateTime.AddSeconds(signingTime.ToUInt64());
                return dateTime.ToLocalTime();
            }
        }

        public string signerCertHash
        {
            get => _signerCertHash == null ? null : encoding.GetString(_signerCertHash).TrimEnd(new char[1]);
            set => _signerCertHash = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string signerSerialNumber
        {
            get => _signerSerialNumber == null ? null : encoding.GetString(_signerSerialNumber).TrimEnd(new char[1]);
            set => _signerSerialNumber = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string signerKeyId
        {
            get => _signerKeyId == null ? null : encoding.GetString(_signerKeyId).TrimEnd(new char[1]);
            set => _signerKeyId = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }
    }
}