using Newtonsoft.Json;
using ProjectFive.Models;
using System.Security.Principal;

namespace ProjectFive.AppFunctions
{
    public class RestaurantApi
    {
        private static HttpClient client = new HttpClient();

        public static List<RestaurantModel> ListRestaurants()
        {
            List<RestaurantModel> restaurants = new List<RestaurantModel>();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://localhost:5283/Restaurant/ListRestaurants"),
                Headers =
                {
                    { "Accept", "application/json" }
                }
            };

            var response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var readData = response.Content.ReadAsStringAsync().Result;
                restaurants = JsonConvert.DeserializeObject<List<RestaurantModel>>(readData);
                return restaurants;
            }
            return null;
        }
    }
}
