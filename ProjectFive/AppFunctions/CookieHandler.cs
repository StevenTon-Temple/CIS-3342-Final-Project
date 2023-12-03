using ProjectFive.Models;
using System.Net;

namespace ProjectFive.AppFunctions
{
    public static class CookieHandler
    {
        public static Cookie CreateCookie(AccountModel account, int days)
        {
            string key = "UserCookie";
            string value = $"{account.ID}|{account.Name}|{account.Username}|{account.Email}|{account.Role}";

            Cookie cookie = new Cookie(key, value);
            cookie.Expires = DateTime.Now.AddDays(days);

            return cookie;
        }

        public static string ReadCookie(string InfoNeeded, Cookie cookie)
        {

            string[] info = cookie.Value.Split('|');

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
