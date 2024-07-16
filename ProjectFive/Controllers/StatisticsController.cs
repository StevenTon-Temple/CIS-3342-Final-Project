using Microsoft.AspNetCore.Mvc;
using ProjectFive.AppFunctions;
using ProjectFive.Models;
using System.Security.Cryptography.X509Certificates;

namespace ProjectFive.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Statistics()
        {
            List<ReviewModel> reviews = ReviewApi.ListAllReviews();

            int fTotal = 0;
            int sTotal = 0;
            int aTotal = 0;
            int pTotal = 0;

            foreach (ReviewModel review in reviews)
            {
                fTotal += review.FoodRating;
                sTotal += review.ServiceRating;
                aTotal += review.AtmosphereRating;
                pTotal += review.PriceRating;
            }

            int totalAmount = reviews.Count;

            double[] avgs = new double[] { fTotal / totalAmount, sTotal / totalAmount, aTotal / totalAmount, pTotal / totalAmount }; 
            return View(avgs);
        }
    }
}
