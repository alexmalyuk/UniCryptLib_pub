using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Script.Serialization;

namespace UniCryptLib
{
    ///<Summary>
    /// Расширение для программных РРО
    ///</Summary>
    [ComVisible(true), ProgId("UniCryptLib.Addin")]
    public class Addin
    {
        private struct CertInfoStruct
        {
            public string GetSerial { get; }
            public string GetSubjOrgUnit { get; }
            public string GetSubjOrg { get; }
            public string GetSubjTitle { get; }
            public string GetIssuer { get; }
            public string GetIssuerCN { get; }
            public string GetSubjAddress { get; }
            public string GetSubjCN { get; }
            public string GetSubject { get; }
            public string GetSubjEDRPOUCode { get; }
            public string GetSubjEMail { get; }
            public string GetSubjFullName { get; }
            public string GetSubjLocality { get; }
            public string GetSubjPhone { get; }
            public string GetSubjState { get; }
            public string GetSubjDRFOCode { get; }
            public string GetSubjDNS { get; }
            public string GetFileSignTimeInfoEx { get; }
            public string GetFileSignTimeInfo { get; }
            public Int32 GetPrivKeyBeginTime { get; }
            public Int32 GetPrivKeyEndTime { get; }
            public string data { get; }

            public CertInfoStruct(UAExtCertInfo cinfo)
            {
                #region  Структура ответа
                //  {
                //        "GetSerial": "35CDD90600000000000000000000000000000001",
                //        "GetSubjOrgUnit": "",
                //        "GetSubjOrg": "ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ \"АЛЛО\"",
                //        "GetSubjTitle": "ДИРЕКТОР",
                //        "GetIssuer": "O=ТОВ \"Центр сертифікації ключів \"Україна\";OU=Відділ сертифікації;CN=АЦСК ТОВ \"Центр сертифікації ключів \"Україна\";Serial=UA-36865753-0117;C=UA;L=Київ",
                //        "GetIssuerCN": "АЦСК ТОВ \"Центр сертифікації ключів \"Україна\"",
                //        "GetSubjAddress": "",
                //        "GetSubjCN": "ЛИСЕНКО КОСТЯНТИН ПЕТРОВИЧ",
                //        "GetSubject": "O=ТОВАРИСТВО З ОБМЕЖЕНОЮ ВІДПОВІДАЛЬНІСТЮ \"АЛЛО\";Title=ДИРЕКТОР;PostalCode=49000;CN=ЛИСЕНКО КОСТЯНТИН ПЕТРОВИЧ;SN=ЛИСЕНКО;GivenName=КОСТЯНТИН ПЕТРОВИЧ;Serial=1984922130D;C=UA;L=місто ДНІПРОПЕТРОВСЬК;ST=ДНІПРОПЕТРОВСЬКА;StreetAddress=ВУЛИЦЯ БАРИКАДНА, БУДИНОК 15-А",
                //        "GetSubjEDRPOUCode": "30012848",
                //        "GetSubjEMail": "30012848@zvit.net",
                //        "GetSubjFullName": "ЛИСЕНКО КОСТЯНТИН ПЕТРОВИЧ",
                //        "GetSubjLocality": "місто ДНІПРОПЕТРОВСЬК",
                //        "GetSubjPhone": "",
                //        "GetSubjState": "ДНІПРОПЕТРОВСЬКА",
                //        "GetSubjDRFOCode": ",1984922130"
                //        "GetSubjDNS": "",
                //        "GetFileSignTimeInfoEx": null,
                //        "GetFileSign TimeInfo": null,	
                //        "GetPrivKeyBeginTime": 1567107208707,
                //        "GetPrivKeyEndTime": 1598659199707,
                //        "data": null
                //    }
                #endregion

                GetSerial = cinfo.serialNumber;
                GetSubjOrgUnit = cinfo.OrganizationalUnitName;
                GetSubjOrg = cinfo.OrganizationName;
                GetSubjTitle = cinfo.Title;
                GetIssuer = cinfo.issuer;
                GetIssuerCN = cinfo.issuer;
                GetSubjAddress = cinfo.Adres;
                GetSubjCN = cinfo.UserName;
                GetSubjEDRPOUCode = cinfo.EDRPOU;
                GetSubjEMail = cinfo.Email;
                GetSubjFullName = cinfo.Name;
                GetSubjLocality = cinfo.Rayon;
                GetSubjPhone = cinfo.Tel;
                GetSubjState = cinfo.Obl;
                GetSubjDRFOCode = cinfo.DRFO;
                GetSubjDNS = "";
                GetFileSignTimeInfoEx = null;
                GetFileSignTimeInfo = null;
                GetPrivKeyBeginTime = (Int32)cinfo.DateBeg;
                GetPrivKeyEndTime = (Int32)cinfo.DateEnd;
                data = null;
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("O={0};", GetSubjOrg);
                sb.AppendFormat("CN={0};", cinfo.CertName);
                sb.AppendFormat("Serial={0};", cinfo.UserSerialNumber);
                sb.AppendFormat("C={0};", cinfo.iUserSerialNumber.Substring(0, 2));
                sb.AppendFormat("L={0};", GetSubjLocality);
                sb.AppendFormat("ST={0};", GetSubjState);
                GetSubject = sb.ToString();
            }
        }

        private struct DecriptedDataStruct
        {
            public string DecriptedData;
            public string SignerSerialNumber;
        }

    private bool isDebug
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }
        private string verInfo
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                //FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                //string version = fvi.FileVersion;

                return assembly.GetName().Version.ToString();
            }
        }
        private Encoding encoding = Encoding.GetEncoding(1251);

        ///<Summary>
        /// Расположение сборки
        ///</Summary>
        public string AssemblyLocation
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                return assembly.Location;
            }
        }

        ///<Summary>
        /// Информация о версии сборки
        ///</Summary>
        public string GetVersionInfo
        {
            get
            {
                return string.Format("Version {0}, DEBUG={1}, Now is {2}", verInfo, isDebug, DateTime.Now);
            }
        }

        ///<Summary>
        /// Получить контрольный номер из строки
        ///</Summary>
        public int CalculateControlNumber(string str)
        {
            return Crc32.CalculateControlNumber(str);
        }

        ///<Summary>
        /// Получить контрольный номер из отдельных параметров
        ///</Summary>
        public int CalculateControlNumber(
          string OflSeed,
          string DocumentDate,
          string DocumentTime,
          long DocumentNumberLocal,
          long CashRegNumberFiscal,
          long CashRegNumberLocal,
          string DocumentSum,
          string DocumentHash)
        {
            return Crc32.CalculateControlNumber(
                OflSeed,
                DocumentDate,
                DocumentTime,
                DocumentNumberLocal,
                CashRegNumberFiscal,
                CashRegNumberLocal,
                DocumentSum,
                DocumentHash);
        }

        ///<Summary>
        /// Подписание данных
        ///</Summary>
        public string SignData(string Key_b64, string Cert_b64, string Password, string Data_b64, bool setTimestamp)
        {
            UniCrypt.Init("");
            CertKeyPair certKeyPair = new CertKeyPair()
            {
                Cert = Convert.FromBase64String(Cert_b64),
                Key = Convert.FromBase64String(Key_b64),
                Pass = Password
            };
            UAExtCertInfo cinfo;
            if (UniCrypt.GetCertInfo(certKeyPair.Cert, out cinfo) == 0
                && cinfo.GetDateBeg <= DateTime.Now
                && (cinfo.GetDateEnd >= DateTime.Now && (cinfo.KeyUsage & TenKeyUsage.enKuDigitalSignature) != TenKeyUsage.enKuNone))
            {
                certKeyPair.CertInfo = cinfo;
                UniCrypt.CurrentCert = certKeyPair;
            }
            else
                throw new Exception("Error creating CertKey pair");

            byte[] sourceData = Convert.FromBase64String(Data_b64);
            byte[] signedData;
            UniCrypt.MakeFirstSign(sourceData, UniCrypt.CurrentCert, setTimestamp, out signedData);

            string signedStr = Convert.ToBase64String(signedData);
            return signedStr;
        }

        ///<Summary>
        /// Извлечение подписанных данных
        ///</Summary>
        public string DecriptData(string SignedData_b64)
        {
            UniCrypt.Init("");

            byte[] signedData = Convert.FromBase64String(SignedData_b64);
            byte[] decriptedData;
            string signerSerialNumber;
            UniCrypt.VerifySign(signedData, out decriptedData, out signerSerialNumber);

            string decriptedStr = encoding.GetString(decriptedData);
            return decriptedStr;
        }

        ///<Summary>
        /// Извлечение подписанных данных и серийного номера ключа подписанта
        ///</Summary>
        public string DecriptDataAsStruct(string SignedData_b64)
        {
            UniCrypt.Init("");

            byte[] signedData = Convert.FromBase64String(SignedData_b64);
            byte[] decriptedData;
            string signerSerialNumber;
            UniCrypt.VerifySign(signedData, out decriptedData, out signerSerialNumber);

            //string decriptedStr = encoding.GetString(decriptedData);
            string decriptedStr = Convert.ToBase64String(decriptedData);

            DecriptedDataStruct decriptedDataStruct = new DecriptedDataStruct 
            { 
                DecriptedData = decriptedStr, 
                SignerSerialNumber = signerSerialNumber
            };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(decriptedDataStruct);

            return json;
        }

        ///<Summary>
        /// Проверка пары Ключ-сертификат, пароля и чтение свойств сертификата
        ///</Summary>
        public string GetCertInfo(string Key_b64, string Cert_b64, string Password)
        {
            UniCrypt.Init("");
            CertKeyPair certKeyPair = new CertKeyPair()
            {
                Cert = Convert.FromBase64String(Cert_b64),
                Key = Convert.FromBase64String(Key_b64),
                Pass = Password
            };

            if (UniCrypt.CheckKeyPair(certKeyPair.Cert, certKeyPair.Key, certKeyPair.Pass) != 0)
                throw new Exception("Error CheckKeyPair");

            UAExtCertInfo cinfo;
            if (UniCrypt.GetCertInfo(certKeyPair.Cert, out cinfo) != 0)
                throw new Exception("Error GetCertInfo");

            CertInfoStruct CertInfo = new CertInfoStruct(cinfo);

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(CertInfo);

            return json;
        }

    }
}
