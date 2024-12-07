using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using UniCryptLib;

namespace UniCryptTest
{
    public class Program
    {

        static void Main(string[] args)
        {
            Encoding encoding = Encoding.GetEncoding(1251);

            string str1 = "Data to encode 123 Данные для подписи 123";
            Console.WriteLine(str1);

            //CertKeyPair certKeyPair = new CertKeyPair()
            //{
            //    Cert = File.ReadAllBytes(@"d:\1111\ТОВ АЛЛО 2022.crt"),
            //    Key = File.ReadAllBytes(@"d:\1111\ТОВ АЛЛО 2022.zs2"),
            //    Pass = "30012848"
            //};

            string Key_b64 = Convert.ToBase64String(File.ReadAllBytes(@"d:\1111\ТОВ АЛЛО 2022.zs2"));
            string Cert_b64 = Convert.ToBase64String(File.ReadAllBytes(@"d:\1111\ТОВ АЛЛО 2022.crt"));
            string Password = "30012848";

            string Data_b64 = Convert.ToBase64String(encoding.GetBytes(str1));

            Addin addin = new Addin();
            Console.WriteLine(addin.GetVersionInfo);

            string str3 = addin.GetCertInfo(Key_b64, Cert_b64, Password);
            Console.WriteLine(str3);

            string signedStr_b64 = addin.SignData(Key_b64, Cert_b64, Password, Data_b64, false);
            //Console.WriteLine(signedStr_b64);

            string str2 = addin.DecriptDataAsStruct(signedStr_b64);

            Console.WriteLine(str2);


            Console.ReadLine();
        }
    }
}
