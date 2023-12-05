using Microsoft.AspNetCore.Mvc;
using ProjectFive.AppFunctions;
using ProjectFive.Models;

namespace ProjectFive.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Create(IFormCollection values)
        {
            string val = values["selectedRestaurant"];
            if (val == null)
            {
                return RedirectToAction("Restaurants", "Restaurant");
            }
            int id = int.Parse(values["selectedRestaurant"]);




            List<RestaurantModel> restaurants = RestaurantApi.ListRestaurants();
            RestaurantModel model = Finder.FindRestaurantByID(id, restaurants);
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateReservation(IFormCollection values)
        {
            int restaurantid = int.Parse(values["rid"]);
            string name = values["name"];
            string phone = values["phone"];
            string date = values["date"];
            string time = values["time"];

            ReservationAPIModel model = new ReservationAPIModel
            {
                id = 0,
                restuarant_id = restaurantid,
                name = name,
                phone = phone,
                datetime = $"{date}|{time}"
            };

            Console.WriteLine(model.ToString());

            bool success = ReservationApi.CreateReservation(model);

            if (success)
            {
                return RedirectToAction("Restaurants", "Restaurant");
            }
            else
            {
                return RedirectToAction("Restaurants", "Restaurant");
            }
        }
    }
}
