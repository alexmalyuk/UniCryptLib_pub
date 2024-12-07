namespace UniCryptLib
{
    public enum TenKeyUsage
    {
        enKuDummy = -1, // 0xFFFFFFFF
        enKuNone = 0,
        enKuEncipherOnly = 1,
        enKuCRLSign = 2,
        enKuKeyCertSign = 4,
        enKuKeyAgreement = 8,
        enKuDataEncipherment = 16, // 0x00000010
        enKuKeyEncipherment = 32, // 0x00000020
        enKuNonRepudiation = 64, // 0x00000040
        enKuDigitalSignature = 128, // 0x00000080
        enKuUnknown = 256, // 0x00000100
        enKuDecipherOnly = 32768, // 0x00008000    }
    }
}