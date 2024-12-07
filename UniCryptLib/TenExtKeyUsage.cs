namespace UniCryptLib
{
    public enum TenExtKeyUsage
    {
        enEKuDummy = -1, // 0xFFFFFFFF
        enEKuNone = 0,
        enEKuOCSP = 2,
        enEKuTSP = 4,
        enEKuAuthServer = 8,
        enEKuAuthClient = 16, // 0x00000010
        enEKuAuthCode = 32, // 0x00000020
        enEKuAuthEmail = 64, // 0x00000040
        enEKuAnyUsage = 512, // 0x00000200
        enEKuCertTypeDir = 65536, // 0x00010000
        enEKuCertTypeBuhg = 131072, // 0x00020000
        enEKuCertTypeStamp = 262144, // 0x00040000
        enEKuCertTypeSgNlNk = 524288, // 0x00080000
        enEKuCertTypeAdmReg = 1048576, // 0x00100000
        enEKuCertTypePhys = 2097152, // 0x00200000
        enEKuCertTypes = 16711680, // 0x00FF0000
    }
}