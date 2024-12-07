namespace UniCryptLib
{
    public enum TenTspResponseFailureInfo
    {
        BadAlg = 0,
        BadRequest = 2,
        BadDataFormat = 5,
        TimeNotAvailable = 14, // 0x0000000E
        UnacceptedPolicy = 15, // 0x0000000F
        UnacceptedExtension = 16, // 0x00000010
        AddInfoNotAvailable = 17, // 0x00000011
        SystemFailure = 25, // 0x00000019
    }
}