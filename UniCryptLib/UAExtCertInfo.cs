using System;
using System.Runtime.InteropServices;
using System.Text;

namespace UniCryptLib
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UAExtCertInfo
    {
        private static readonly Encoding encoding = Encoding.GetEncoding(1251);
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _serialNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _subjectKeyIdentifier;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _authorityKeyIdentifier;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _issuer;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _issuerID;
        public UIntPtr DateBeg;
        public UIntPtr DateEnd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        private byte[] _EDRPOU;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        private byte[] _DRFO;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _Name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _Email;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _Title;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        private byte[] _PostalCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _Obl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _Rayon;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _Adres;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _Tel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _Qualifier;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _Surname;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _GivenName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _UserSerialNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _OrganizationName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _OrganizationalUnitName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        private byte[] _EDDRU;
        [MarshalAs(UnmanagedType.I4)]
        public TenKeyUsage KeyUsage;
        [MarshalAs(UnmanagedType.I4)]
        public TenExtKeyUsage ExtKeyUsage;
        [MarshalAs(UnmanagedType.I4)]
        public int BasicConstraints;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        private byte[] _CRLDistributionPoints;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        private byte[] _CRLDeltaDistributionPoints;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        private byte[] _accessCaRepository;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        private byte[] _accessTimeStamping;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _accessOCSP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _accessCaIssuers;
        [MarshalAs(UnmanagedType.I4)]
        public TenPublicKeyAlgorithm pkAlg;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _pkAlgOid;
        [MarshalAs(UnmanagedType.I4)]
        public int isQualified;
        public int isKeyInDevice;
        [MarshalAs(UnmanagedType.I4)]
        public int hasLimitValue;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _currencyCode;
        [MarshalAs(UnmanagedType.I4)]
        public int amount;
        [MarshalAs(UnmanagedType.I4)]
        public int exponent;
        [MarshalAs(UnmanagedType.I4)]
        public int Type;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        private byte[] _iEDRPOU;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        private byte[] _iDRFO;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iEmail;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iTitle;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        private byte[] _iPostalCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iObl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iRayon;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iAdres;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iTel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iQualifier;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iSurname;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iGivenName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iUserSerialNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iOrganizationName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _iOrganizationalUnitName;
        public IntPtr ExtKeyUsageExt;
        public int ExtKeyUsageExtLen;

        public string serialNumber
        {
            get => _serialNumber == null ? null : encoding.GetString(_serialNumber).TrimEnd(new char[1]);
            set => _serialNumber = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string subjectKeyIdentifier
        {
            get => _subjectKeyIdentifier == null ? null : encoding.GetString(_subjectKeyIdentifier).TrimEnd(new char[1]);
            set => _subjectKeyIdentifier = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string authorityKeyIdentifier
        {
            get => _authorityKeyIdentifier == null ? null : encoding.GetString(_authorityKeyIdentifier).TrimEnd(new char[1]);
            set => _authorityKeyIdentifier = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string issuer
        {
            get => _issuer == null ? null : encoding.GetString(_issuer).TrimEnd(new char[1]);
            set => _issuer = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string issuerID
        {
            get => _issuerID == null ? null : encoding.GetString(_issuerID).TrimEnd(new char[1]);
            set => _issuerID = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public DateTime GetDateBeg
        {
            get
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
                dateTime = dateTime.AddSeconds(DateBeg.ToUInt64());
                return dateTime.ToLocalTime();
            }
        }

        public DateTime GetDateEnd
        {
            get
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
                dateTime = dateTime.AddSeconds(DateEnd.ToUInt64());
                return dateTime.ToLocalTime();
            }
        }

        public string EDRPOU
        {
            get => _EDRPOU == null ? null : encoding.GetString(_EDRPOU).TrimEnd(new char[1]);
            set => _EDRPOU = encoding.GetBytes(((value ?? "").Length > 14 ? (value ?? "").Substring(0, 14) : ((value ?? "").Length < 14 ? (value ?? "").PadRight(14, char.MinValue) : value ?? "")) + "\0");
        }

        public string CertEDRPOU => EDRPOU;

        public string DRFO
        {
            get => _DRFO == null ? null : encoding.GetString(_DRFO).TrimEnd(new char[1]);
            set => _DRFO = encoding.GetBytes(((value ?? "").Length > 14 ? (value ?? "").Substring(0, 14) : ((value ?? "").Length < 14 ? (value ?? "").PadRight(14, char.MinValue) : value ?? "")) + "\0");
        }

        public string CertDRFO => DRFO;

        public string Name
        {
            get => _Name == null ? null : encoding.GetString(_Name).TrimEnd(new char[1]);
            set => _Name = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string CertName => Name;

        public string Email
        {
            get => _Email == null ? null : encoding.GetString(_Email).TrimEnd(new char[1]);
            set => _Email = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string Title
        {
            get => _Title == null ? null : encoding.GetString(_Title).TrimEnd(new char[1]);
            set => _Title = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string PostalCode
        {
            get => _PostalCode == null ? null : encoding.GetString(_PostalCode).TrimEnd(new char[1]);
            set => _PostalCode = encoding.GetBytes(((value ?? "").Length > 14 ? (value ?? "").Substring(0, 14) : ((value ?? "").Length < 14 ? (value ?? "").PadRight(14, char.MinValue) : value ?? "")) + "\0");
        }

        public string Obl
        {
            get => _Obl == null ? null : encoding.GetString(_Obl).TrimEnd(new char[1]);
            set => _Obl = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string Rayon
        {
            get => _Rayon == null ? null : encoding.GetString(_Rayon).TrimEnd(new char[1]);
            set => _Rayon = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string Adres
        {
            get => _Adres == null ? null : encoding.GetString(_Adres).TrimEnd(new char[1]);
            set => _Adres = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string Tel
        {
            get => _Tel == null ? null : encoding.GetString(_Tel).TrimEnd(new char[1]);
            set => _Tel = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string Qualifier
        {
            get => _Qualifier == null ? null : encoding.GetString(_Qualifier).TrimEnd(new char[1]);
            set => _Qualifier = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string Surname
        {
            get => _Surname == null ? null : encoding.GetString(_Surname).TrimEnd(new char[1]);
            set => _Surname = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string GivenName
        {
            get => _GivenName == null ? null : encoding.GetString(_GivenName).TrimEnd(new char[1]);
            set => _GivenName = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string UserName => Surname + " " + GivenName;

        public string UserSerialNumber
        {
            get => _UserSerialNumber == null ? null : encoding.GetString(_UserSerialNumber).TrimEnd(new char[1]);
            set => _UserSerialNumber = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string OrganizationName
        {
            get => _OrganizationName == null ? null : encoding.GetString(_OrganizationName).TrimEnd(new char[1]);
            set => _OrganizationName = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string OrganizationalUnitName
        {
            get => _OrganizationalUnitName == null ? null : encoding.GetString(_OrganizationalUnitName).TrimEnd(new char[1]);
            set => _OrganizationalUnitName = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string EDDRU
        {
            get => _EDDRU == null ? null : encoding.GetString(_EDDRU).TrimEnd(new char[1]);
            set => _EDDRU = encoding.GetBytes(((value ?? "").Length > 14 ? (value ?? "").Substring(0, 14) : ((value ?? "").Length < 14 ? (value ?? "").PadRight(14, char.MinValue) : value ?? "")) + "\0");
        }

        public string CRLDistributionPoints
        {
            get => _CRLDistributionPoints == null ? null : encoding.GetString(_CRLDistributionPoints).TrimEnd(new char[1]);
            set => _CRLDistributionPoints = encoding.GetBytes(((value ?? "").Length > byte.MaxValue ? (value ?? "").Substring(0, byte.MaxValue) : ((value ?? "").Length < byte.MaxValue ? (value ?? "").PadRight(byte.MaxValue, char.MinValue) : value ?? "")) + "\0");
        }

        public string CRLDeltaDistributionPoints
        {
            get => _CRLDeltaDistributionPoints == null ? null : encoding.GetString(_CRLDeltaDistributionPoints).TrimEnd(new char[1]);
            set => _CRLDeltaDistributionPoints = encoding.GetBytes(((value ?? "").Length > byte.MaxValue ? (value ?? "").Substring(0, byte.MaxValue) : ((value ?? "").Length < byte.MaxValue ? (value ?? "").PadRight(byte.MaxValue, char.MinValue) : value ?? "")) + "\0");
        }

        public string accessCaRepository
        {
            get => _accessCaRepository == null ? null : encoding.GetString(_accessCaRepository).TrimEnd(new char[1]);
            set => _accessCaRepository = encoding.GetBytes(((value ?? "").Length > byte.MaxValue ? (value ?? "").Substring(0, byte.MaxValue) : ((value ?? "").Length < byte.MaxValue ? (value ?? "").PadRight(byte.MaxValue, char.MinValue) : value ?? "")) + "\0");
        }

        public string accessTimeStamping
        {
            get => _accessTimeStamping == null ? null : encoding.GetString(_accessTimeStamping).TrimEnd(new char[1]);
            set => _accessTimeStamping = encoding.GetBytes(((value ?? "").Length > byte.MaxValue ? (value ?? "").Substring(0, byte.MaxValue) : ((value ?? "").Length < byte.MaxValue ? (value ?? "").PadRight(byte.MaxValue, char.MinValue) : value ?? "")) + "\0");
        }

        public string accessOCSP
        {
            get => _accessOCSP == null ? null : encoding.GetString(_accessOCSP).TrimEnd(new char[1]);
            set => _accessOCSP = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string accessCaIssuers
        {
            get => _accessCaIssuers == null ? null : encoding.GetString(_accessCaIssuers).TrimEnd(new char[1]);
            set => _accessCaIssuers = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string pkAlgOid
        {
            get => _pkAlgOid == null ? null : encoding.GetString(_pkAlgOid).TrimEnd(new char[1]);
            set => _pkAlgOid = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string currencyCode
        {
            get => _currencyCode == null ? null : encoding.GetString(_currencyCode).TrimEnd(new char[1]);
            set => _currencyCode = encoding.GetBytes(((value ?? "").Length > 3 ? (value ?? "").Substring(0, 3) : ((value ?? "").Length < 3 ? (value ?? "").PadRight(3, char.MinValue) : value ?? "")) + "\0");
        }

        public string iEDRPOU
        {
            get => _iEDRPOU == null ? null : encoding.GetString(_iEDRPOU).TrimEnd(new char[1]);
            set => _iEDRPOU = encoding.GetBytes(((value ?? "").Length > 14 ? (value ?? "").Substring(0, 14) : ((value ?? "").Length < 14 ? (value ?? "").PadRight(14, char.MinValue) : value ?? "")) + "\0");
        }

        public string iDRFO
        {
            get => _iDRFO == null ? null : encoding.GetString(_iDRFO).TrimEnd(new char[1]);
            set => _iDRFO = encoding.GetBytes(((value ?? "").Length > 14 ? (value ?? "").Substring(0, 14) : ((value ?? "").Length < 14 ? (value ?? "").PadRight(14, char.MinValue) : value ?? "")) + "\0");
        }

        public string iName
        {
            get => _iName == null ? null : encoding.GetString(_iName).TrimEnd(new char[1]);
            set => _iName = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iEmail
        {
            get => _iEmail == null ? null : encoding.GetString(_iEmail).TrimEnd(new char[1]);
            set => _iEmail = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iTitle
        {
            get => _iTitle == null ? null : encoding.GetString(_iTitle).TrimEnd(new char[1]);
            set => _iTitle = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iPostalCode
        {
            get => _iPostalCode == null ? null : encoding.GetString(_iPostalCode).TrimEnd(new char[1]);
            set => _iPostalCode = encoding.GetBytes(((value ?? "").Length > 14 ? (value ?? "").Substring(0, 14) : ((value ?? "").Length < 14 ? (value ?? "").PadRight(14, char.MinValue) : value ?? "")) + "\0");
        }

        public string iObl
        {
            get => _iObl == null ? null : encoding.GetString(_iObl).TrimEnd(new char[1]);
            set => _iObl = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iRayon
        {
            get => _iRayon == null ? null : encoding.GetString(_iRayon).TrimEnd(new char[1]);
            set => _iRayon = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iAdres
        {
            get => _iAdres == null ? null : encoding.GetString(_iAdres).TrimEnd(new char[1]);
            set => _iAdres = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iTel
        {
            get => _iTel == null ? null : encoding.GetString(_iTel).TrimEnd(new char[1]);
            set => _iTel = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iQualifier
        {
            get => _iQualifier == null ? null : encoding.GetString(_iQualifier).TrimEnd(new char[1]);
            set => _iQualifier = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iSurname
        {
            get => _iSurname == null ? null : encoding.GetString(_iSurname).TrimEnd(new char[1]);
            set => _iSurname = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iGivenName
        {
            get => _iGivenName == null ? null : encoding.GetString(_iGivenName).TrimEnd(new char[1]);
            set => _iGivenName = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iUserSerialNumber
        {
            get => _iUserSerialNumber == null ? null : encoding.GetString(_iUserSerialNumber).TrimEnd(new char[1]);
            set => _iUserSerialNumber = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iOrganizationName
        {
            get => _iOrganizationName == null ? null : encoding.GetString(_iOrganizationName).TrimEnd(new char[1]);
            set => _iOrganizationName = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string iOrganizationalUnitName
        {
            get => _iOrganizationalUnitName == null ? null : encoding.GetString(_iOrganizationalUnitName).TrimEnd(new char[1]);
            set => _iOrganizationalUnitName = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }
    }
}
