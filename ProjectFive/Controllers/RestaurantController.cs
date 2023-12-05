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
        public IActionResult Create()
        {
            return View("Create");
        }

        public IActionResult MoreDetails(IFormCollection values)
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

        public IActionResult EditRestaurant(IFormCollection values)
        {
            int id = int.Parse(values["rid"]);



            if (id == null)
            {
                return View("Restaurants");
            }
            List<RestaurantModel> restaurants = RestaurantApi.ListRestaurants();
            RestaurantModel model = Finder.FindRestaurantByID(id, restaurants);

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateRestaurant(IFormCollection values)
        {
            int id = int.Parse(values["restaurantID"]);
            int repId = int.Parse(values["representativeID"]);
            string img = values["image"];
            string name = values["name"];
            string description = values["description"];
            double rating = double.Parse(values["rating"]);
            string category = values["category"];

            RestaurantAPIModel model = new RestaurantAPIModel
            {
                id = id,
                representative_id = repId,
                image = img,
                name = name,
                description = description,
                rating = rating,
                category = category
            };

            bool success = RestaurantApi.UpdateRestaurant(model);

            if (success)
            {
                return RedirectToAction("Restaurants", "Restaurant");
            }
            return RedirectToAction("Restaurants", "Restaurant");
        }

        [HttpPost]
        public IActionResult DeleteRestaurant(IFormCollection values)
        {
            int id = int.Parse(values["rid"]);

            if (id == null)
            {
                RedirectToAction("Restaurants", "Restaurant");
            }
            
            bool success = RestaurantApi.DeleteRestaurant(id);

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
        public IActionResult UpdateRepresentative(IFormCollection values)
        {
            int id = int.Parse(values["rid"]);
            int repId = int.Parse(values["repid"]);

            if (id == null)
            {
                return RedirectToAction("Restaurants", "Restaurant");
            }

            List<RestaurantModel> restaurants = RestaurantApi.ListRestaurants();
            RestaurantModel model = Finder.FindRestaurantByID(id, restaurants);

            RestaurantAPIModel r = new RestaurantAPIModel
            {
                id = model.ID,
                representative_id = repId,
                image = model.Image,
                name = model.Name,
                description = model.Description,
                rating = model.Rating,
                category = model.Category
            };

            bool success = RestaurantApi.UpdateRestaurant(r);

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
        public IActionResult CreateRestaurant(IFormCollection values)
        {
            string name = values["name"];
            string description = values["description"];
            string image = values["image"];
            string category = values["category"];

            RestaurantAPIModel r = new RestaurantAPIModel
            {
                id = 0,
                representative_id = 0,
                image = image,
                name = name,
                description = description,
                rating = 0,
                category = category
            };

            bool success = RestaurantApi.CreateRestaurant(r);

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
