using Microsoft.AspNetCore.Mvc;
using ProjectFive.AppFunctions;
using ProjectFive.Models;
using System.Net;

namespace ProjectFive.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            var cookie = Request.Cookies["UserCookie"];

            if(cookie != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection values)
        {
            

            string username = values["username"];
            string password = values["password"];
            string selected = values["remember"];

            

            AccountModel model = AccountApi.VerifyAccount(username, password);

            if(model != null)
            {
                if(selected == "false")
                {
                    CreateCookieMinutes(model, 45);
                }
                else
                {
                    CreateCookie(model, 7);
                }
                return RedirectToAction("Restaurants", "Restaurant");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpPost]
        public IActionResult Register(IFormCollection values)
        {
            string email = values["email"];
            string username = values["username"];
            string password = values["password"];
            string name = values["name"];
            string role = values["role"];
            int roleId;

            if(role == "Reviewer")
            {
                roleId = 1;
            }
            else
            {
                roleId = 2;
            }

            AccountApiModel account = new AccountApiModel
            {
                id = 0,
                email = email,
                username = username,
                password = password,
                name = name,
                role = role,
                role_ID = roleId
            };

            bool success = AccountApi.CreateAccount(account);

            if(success)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public IActionResult SendCode(IFormCollection values)
        {
            string email = values["email"];

            Random r = new Random();

            int code = r.Next(1000, 9999);

            string username = AccountApi.GetAccountUserName(email);

            Mailer.SendMessage(code.ToString(), username, email);
            AccountApi.CreateCodeEntry(code, email);

            return View("Forgot");
        }

        [HttpPost]
        public IActionResult ForgotPassword(IFormCollection values)
        {
            string email = values["email"];
            int code = int.Parse(values["code"]);
            string password = values["password"];

            bool success = AccountApi.VerifyCode(code, email);

            if(success)
            {
                AccountModel model = AccountApi.ForgotAccount(password, email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Forgot");
            }
        }


        private void CreateCookie(AccountModel account, int days)
        {
            string key = "UserCookie";
            string value = $"{account.ID}|{account.Name}|{account.Username}|{account.Email}|{account.Role}";
            var cookieOptions = new CookieOptions();

            cookieOptions.Expires = DateTime.Now.AddDays(days);
            cookieOptions.Path = "/";

            Response.Cookies.Append(key, value, cookieOptions);
        }

        private void CreateCookieMinutes(AccountModel account, int minutes)
        {
            string key = "UserCookie";
            string value = $"{account.ID}|{account.Name}|{account.Username}|{account.Email}|{account.Role}";
            var cookieOptions = new CookieOptions();

            cookieOptions.Expires = DateTime.Now.AddMinutes(minutes);
            cookieOptions.Path = "/";

            Response.Cookies.Append(key, value, cookieOptions);
        }

    }
}
