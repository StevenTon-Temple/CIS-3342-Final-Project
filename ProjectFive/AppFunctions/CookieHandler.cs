using Org.BouncyCastle.Asn1.Ocsp;
using ProjectFive.Models;
using System.Net;
using System.Security.Cryptography;

namespace ProjectFive.AppFunctions
{
    public class CookieHandler
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        public string ReadCookie(string InfoNeeded, string value)
        {

            string decoded = EncryptionCust.DecodeAndDecrypt(value);

            string[] info = decoded.Split('|');

            foreach(string s in info)
            {
                Console.WriteLine(s);
            }

            switch (InfoNeeded)
            {
                case "ID":
                    return info[0].Trim();
                case "Name":
                    return info[1].Trim();
                case "Username":
                    return info[2].Trim();
                case "Email":
                    return info[3].Trim();
                case "Role":
                    return info[4].Trim();
            }

            return null;
        }

        public static string ReadStaticCookie(string InfoNeeded, string value)
        {

            string decoded = EncryptionCust.DecodeAndDecrypt(value);

            string[] info = decoded.Split('|');

            foreach (string s in info)
            {
                Console.WriteLine(s);
            }

            switch (InfoNeeded)
            {
                case "ID":
                    return info[0].Trim();
                case "Name":
                    return info[1].Trim();
                case "Username":
                    return info[2].Trim();
                case "Email":
                    return info[3].Trim();
                case "Role":
                    return info[4].Trim();
            }

            return null;
        }



    }
}
