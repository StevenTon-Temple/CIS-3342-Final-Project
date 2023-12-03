using Microsoft.AspNetCore.Mvc;
using ProjectFive.AppFunctions;
using ProjectFive.Models;

namespace ProjectFive.Controllers
{
    public class RestaurantController : Controller
    {
        readonly List<RestaurantModel> restaurants = RestaurantApi.ListRestaurants();
        public IActionResult Restaurants()
        {
            return View(restaurants);
        }
    }
}
