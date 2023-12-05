using Microsoft.AspNetCore.Mvc;
using ProjectFive.AppFunctions;
using ProjectFive.Models;

namespace ProjectFive.Controllers
{
    public class ReviewController : Controller
    {
        readonly List<ReviewModel> reviews = ReviewApi.ListReviews();
        public IActionResult Review()
        {
            return View(reviews);
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection values)
        {
            return View("Edit");
        }
        [HttpPost]
        public IActionResult Add(IFormCollection values)
        {
            string name = values["name"];
            int price = Convert.ToInt32(values["price"]);
            int service = Convert.ToInt32(values["service"]);
            int food = Convert.ToInt32(values["food"]);
            int atmo = Convert.ToInt32(values["atmo"]);
            string description = values["description"];
            int totalRating = (price + service + food + atmo) / 4;

            ReviewApiModel review = new ReviewApiModel
            {
                ResturantID = 2,
                ReviwerID = 0,
                PriceRating = price,
                ServiceRating = service,
                FoodRating = food,
                AtmosphereRating = atmo,
                Description = description

            };
            bool success = ReviewApi.CreateReview(review);
            if (success)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Add");
            }
        }
    }
}
