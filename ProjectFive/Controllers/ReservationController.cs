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

        public IActionResult Representative()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HandleAction(IFormCollection values)
        {
            int id = int.Parse(values["selectedReservation"]);
            string action = values["actionType"];

            if(id == null)
            {
                return RedirectToAction("Representative", "Reservation");
            }
            
            if(action == "delete")
            {
                bool success = ReservationApi.DeleteReservation(id);
                return RedirectToAction("Representative", "Reservation");
            }

            else if(action == "edit")
            {
                List<ReservationModel> reservations = ReservationApi.ListReservations();
                ReservationModel selected = new ReservationModel();

                foreach(ReservationModel r in reservations)
                {
                    if(r.ID == id)
                    {
                        selected = r;
                        break;
                    }
                }

                return View("Edit", selected);
            }

            return RedirectToAction("Representative", "Reservation");
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

        [HttpPost]
        public IActionResult UpdateReservation(IFormCollection values)
        {
            int id = int.Parse(values["id"]);
            int restaurantid = int.Parse(values["rid"]);
            string name = values["name"];
            string phone = values["phone"];
            string date = values["date"];
            string time = values["time"];

            ReservationAPIModel model = new ReservationAPIModel
            {
                id = id,
                restuarant_id = restaurantid,
                name = name,
                phone = phone,
                datetime = $"{date}|{time}"
            };

            bool success = ReservationApi.UpdateReservation(model);

            if (success)
            {
                return RedirectToAction("Representative", "Reservation");
            }
            else
            {
                return RedirectToAction("Representative", "Reservation");
            }
        }
    }
}
