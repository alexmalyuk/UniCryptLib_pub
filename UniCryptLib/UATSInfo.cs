using System;
using System.Runtime.InteropServices;
using System.Text;

namespace UniCryptLib
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UATSInfo
    {
        private static readonly Encoding encoding = Encoding.GetEncoding(1251);
        [MarshalAs(UnmanagedType.I4)]
        public TenTspResponseStatus status;
        [MarshalAs(UnmanagedType.I4)]
        public TenTspResponseFailureInfo failInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] hash;
        private UIntPtr genTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _signerKeyIdentifier;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _serialNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _nonce;
        public UARecord includedCert;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        private byte[] _signerSerialNumber;
        public UASubjectInfo signerIssuer;

        public DateTime GetGenTime
        {
            get
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
                dateTime = dateTime.AddSeconds(genTime.ToUInt64());
                return dateTime.ToLocalTime();
            }
            set => genTime = new UIntPtr((uint)(value - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);
        }

        public string signerKeyIdentifier
        {
            get => _signerKeyIdentifier == null ? null : encoding.GetString(_signerKeyIdentifier).TrimEnd(new char[1]);
            set => _signerKeyIdentifier = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string serialNumber
        {
            get => _serialNumber == null ? null : encoding.GetString(_serialNumber).TrimEnd(new char[1]);
            set => _serialNumber = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string nonce
        {
            get => _nonce == null ? null : encoding.GetString(_nonce).TrimEnd(new char[1]);
            set => _nonce = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }

        public string signerSerialNumber
        {
            get => _signerSerialNumber == null ? null : encoding.GetString(_signerSerialNumber).TrimEnd(new char[1]);
            set => _signerSerialNumber = encoding.GetBytes(((value ?? "").Length > 64 ? (value ?? "").Substring(0, 64) : ((value ?? "").Length < 64 ? (value ?? "").PadRight(64, char.MinValue) : value ?? "")) + "\0");
        }
    }
}
