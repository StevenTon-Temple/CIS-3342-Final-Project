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
    }
}
