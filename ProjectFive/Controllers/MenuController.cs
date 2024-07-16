using Microsoft.AspNetCore.Mvc;
using ProjectFive.AppFunctions;
using ProjectFive.Models;

namespace ProjectFive.Controllers
{
    public class MenuController : Controller
    {
        
        public IActionResult Menu(IFormCollection values)
        {
            List<MenuModel.MenuItems> Menu = MenuApi.ListMenu(values["menuSearch"]);
            return View(Menu);
        }
    }
}
