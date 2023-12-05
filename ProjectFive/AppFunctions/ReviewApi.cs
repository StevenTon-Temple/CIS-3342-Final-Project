using Newtonsoft.Json;
using ProjectFive.Models;

namespace ProjectFive.AppFunctions
{
    public class ReviewApi
    {
        private static HttpClient client = new HttpClient();

        public static List<ReviewModel> ListReviews()
        {
            List<ReviewModel> reviews = new List<ReviewModel>();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://localhost:5283/Review/ListReviews"),
                Headers =
                {
                    { "Accept", "application/json" }
                }
            };

            var response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var readData = response.Content.ReadAsStringAsync().Result;
                reviews = JsonConvert.DeserializeObject<List<ReviewModel>>(readData);
                return reviews;
            }
            return null;
        }

        public static bool CreateReview(ReviewApiModel review)
        {
            var content = JsonConvert.SerializeObject(review, Formatting.Indented);
            Console.WriteLine(content);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:5283/Review/CreateReview"),
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
