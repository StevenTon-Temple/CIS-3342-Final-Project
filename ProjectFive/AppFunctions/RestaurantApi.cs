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
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Restaurant/ListRestaurants"),
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

        public static bool UpdateRestaurant(RestaurantAPIModel restaurant)
        {
            var content = JsonConvert.SerializeObject(restaurant, Formatting.Indented);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Restaurant/UpdateRestaurant"),
                Headers =
                {
                    { "Accept", "application/json" }
                },
                Content = new StringContent(content)
                {
                    Headers =
                    {
                        ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
                    }
                }
            };

            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteRestaurant(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Restaurant/DeleteRestaurant?id={id}"),
                Headers =
                {
                    { "Accept", "application/json" }
                }
            };
            var response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public static bool CreateRestaurant(RestaurantAPIModel restaurant)
        {
            var content = JsonConvert.SerializeObject(restaurant, Formatting.Indented);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Restaurant/CreateRestaurant"),
                Headers =
                {
                    { "Accept", "application/json" }
                },
                Content = new StringContent(content)
                {
                    Headers =
                    {
                        ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
                    }
                }
            };

            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
