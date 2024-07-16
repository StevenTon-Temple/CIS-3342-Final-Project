using ProjectFive.Models;

namespace ProjectFive.AppFunctions
{
    public class Finder
    {
        public static RestaurantModel FindRestaurantByID(int id, List<RestaurantModel> restaurants)
        {
            foreach(RestaurantModel r in restaurants)
            {
                if(r.ID == id) return r;
            }

            return null;
        }

        public static ReviewModel FindUserReviewByIDEdit(int id, List<ReviewModel> reviews)
        {
            foreach (ReviewModel r in reviews)
            {
                if (r.ID == id) return r;
            }

            return null;
        }
    }
}
