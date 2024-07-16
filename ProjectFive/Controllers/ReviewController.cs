using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Cmp;
using Org.BouncyCastle.Ocsp;
using ProjectFive.AppFunctions;
using ProjectFive.Models;
using System.Security.Cryptography;

namespace ProjectFive.Controllers
{
    public class ReviewController : Controller
    {

        public IActionResult Review()
        {
            var cookie = Request.Cookies["UserCookie"];
            int id;
            id = int.Parse(CookieHandler.ReadStaticCookie("ID", cookie));
            List<ReviewModel> reviews = ReviewApi.ListReviews(id);

            return View(reviews);
        }



        [HttpPost]
        public IActionResult Edit(IFormCollection values)
        {
            string val = values["selectedReview"];
            var cookie = Request.Cookies["UserCookie"];
            int revid;
            revid = int.Parse(CookieHandler.ReadStaticCookie("ID", cookie));

            Console.WriteLine(val + " value");
            if (val == null || val == "0")
            {
                return RedirectToAction("Review", "Review");
            }
            int id = int.Parse(val);



            List<ReviewModel> reviews = ReviewApi.ListReviews(revid);
            ReviewModel model = Finder.FindUserReviewByIDEdit(id, reviews);

            return View(model);
        }


        public IActionResult Rep()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormCollection values)
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
        public IActionResult AddReview(IFormCollection values)
        {
            var cookie = Request.Cookies["UserCookie"];
            int revid;
            revid = int.Parse(CookieHandler.ReadStaticCookie("ID", cookie));

            int price = Convert.ToInt32(values["price"]);
            int service = Convert.ToInt32(values["service"]);
            int food = Convert.ToInt32(values["food"]);
            int atmo = Convert.ToInt32(values["atmo"]);
            string description = values["description"];
            int rId = Convert.ToInt32(values["rid"]);


            ReviewApiModel review = new ReviewApiModel
            {
                ResturantID = rId,
                ReviwerID = revid,
                PriceRating = price,
                ServiceRating = service,
                FoodRating = food,
                AtmosphereRating = atmo,
                Description = description

            };
            bool success = ReviewApi.CreateReview(review);
            if (success)
            {
                return RedirectToAction("Review", "Review");
            }
            else
            {
                return View("Add");
            }
        }
        [HttpPost]
        public IActionResult UpdateReview(IFormCollection values)
        {
            int id = Convert.ToInt32(values["reviewid"]);
            int restId = Convert.ToInt32(values["restId"]);

            int revId = Convert.ToInt32(values["revid"]);
            int price = Convert.ToInt32(values["price"]);
            int service = Convert.ToInt32(values["serv"]);
            int food = Convert.ToInt32(values["food"]);
            int atmo = Convert.ToInt32(values["atmo"]);
            string description = values["desc"];



            ReviewApiModel review = new ReviewApiModel
            {
                ID = id,
                ResturantID = restId,
                ReviwerID = revId,
                PriceRating = price,
                ServiceRating = service,
                FoodRating = food,
                AtmosphereRating = atmo,
                Description = description

            };
            bool success = ReviewApi.UpdateReview(review);
            if (success)
            {
                return RedirectToAction("Review", "Review");
            }
            else
            {
                return View("Edit");
            }

        }


        [HttpPost]
        public IActionResult DeleteReview(IFormCollection values)
        {
            int id = int.Parse(values["selectedReview"]);

            if (id == null)
            {
                return RedirectToAction("Review", "Review");
            }

            bool success = ReviewApi.DeleteReview(id);

            if (success)
            {
                return RedirectToAction("Review", "Review");
            }
            else
            {
                return RedirectToAction("Review", "Review");
            }
        }

       
    }
}