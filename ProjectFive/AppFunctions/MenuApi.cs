using Newtonsoft.Json;
using ProjectFive.Models;
using static ProjectFive.Models.MenuModel;

namespace ProjectFive.AppFunctions
{
    public class MenuApi
    {
        private static HttpClient client = new HttpClient();
        public static List<MenuItems> ListMenu(string menuItem)
        {
            List<MenuModel> menu = new List<MenuModel>();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/food/menuItems/search?query={menuItem}&offset=0&number=10&minCalories=0&maxCalories=5000&minProtein=0&maxProtein=100&minFat=0&maxFat=100&minCarbs=0&maxCarbs=100"),
                Headers =
                {
                    { "Accept", "application/json" },
                    { "X-RapidAPI-Key", "4a366c00bbmsh47f3d91fc1d37fap184d6bjsn088f97de2195" },
                    { "X-RapidAPI-Host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" },
                }
            };

            var response = client.SendAsync(request).Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync().Result;
                CallRoot root = JsonConvert.DeserializeObject<CallRoot>(read);
                return root.menuItems;
            }
            return null;
        }
    }
}

