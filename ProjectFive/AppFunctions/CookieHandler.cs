using ProjectFive.Models;
using System.Net;

namespace ProjectFive.AppFunctions
{
    public class CookieHandler
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public static Cookie CreateCookie(AccountModel account, int days)
        {
            string key = "UserCookie";
            string value = $"{account.ID}|{account.Name}|{account.Username}|{account.Email}|{account.Role}";

            Cookie cookie = new Cookie(key, value);
            cookie.Expires = DateTime.Now.AddDays(days);

            return cookie;
        }

        public string ReadCookie(string InfoNeeded, string value)
        {

            string[] info = value.Split('|');

            switch(InfoNeeded)
            {
                case "ID":
                    return info[0];
                case "Name":
                    return info[1];
                case "Username":
                    return info[2];
                case "Email":
                    return info[3];
                case "Role":
                    return info[4];
            }

            return null;
        }
    }
}
