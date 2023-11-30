using Microsoft.AspNetCore.Mvc;
using ProjectFive.AppFunctions;
using ProjectFive.Models;

namespace ProjectFive.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
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
            

            string email = values["username"];
            string password = values["password"];

            

            AccountModel model = AccountApi.VerifyAccount(email, password);

            if(model != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpPost]
        public IActionResult Register(IFormCollection values)
        {
            string email = values["username"];
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
            string email = values["username"];

            Random r = new Random();

            int code = r.Next(1000, 9999);


        }
    }
}
