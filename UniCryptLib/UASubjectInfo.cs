using System;
using System.Runtime.InteropServices;
using System.Text;

namespace UniCryptLib

{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UASubjectInfo
    {
        private static readonly Encoding encoding = Encoding.GetEncoding(1251);
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
        private byte[] _SerialNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _OrganizationName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _OrganizationalUnitName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        private byte[] _EDDRU;

        public string EDRPOU
        {
            get => _EDRPOU == null ? null : encoding.GetString(_EDRPOU).TrimEnd(new char[1]);
            set => _EDRPOU = encoding.GetBytes(((value ?? "").Length > 14 ? (value ?? "").Substring(0, 14) : ((value ?? "").Length < 14 ? (value ?? "").PadRight(14, char.MinValue) : value ?? "")) + "\0");
        }

        public string DRFO
        {
            get => _DRFO == null ? null : encoding.GetString(_DRFO).TrimEnd(new char[1]);
            set => _DRFO = encoding.GetBytes(((value ?? "").Length > 14 ? (value ?? "").Substring(0, 14) : ((value ?? "").Length < 14 ? (value ?? "").PadRight(14, char.MinValue) : value ?? "")) + "\0");
        }

        public string Name
        {
            get => _Name == null ? null : encoding.GetString(_Name).TrimEnd(new char[1]);
            set => _Name = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

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

        public string SerialNumber
        {
            get => _SerialNumber == null ? null : encoding.GetString(_SerialNumber).TrimEnd(new char[1]);
            set => _SerialNumber = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
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
    }
}
