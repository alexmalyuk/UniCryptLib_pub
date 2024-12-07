namespace UniCryptLib
{
    public class CertKeyPair
    {
        public UAExtCertInfo CertInfo { get; set; }

        public byte[] Cert { get; set; }

        public byte[] Key { get; set; }

        public string Pass { get; set; }
    }
}
