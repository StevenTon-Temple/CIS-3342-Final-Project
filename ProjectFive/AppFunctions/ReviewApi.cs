using Newtonsoft.Json;
using ProjectFive.Models;

namespace ProjectFive.AppFunctions
{
    public class ReviewApi
    {
        private static HttpClient client = new HttpClient();

        public static List<ReviewModel> ListReviews(int id)
        {
            List<ReviewModel> reviews = new List<ReviewModel>();
            Console.WriteLine(id);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Review/ListReviews?id={id}"),
                Headers =
                {
                    { "Accept", "application/json" }
                }
            };

            var response = client.SendAsync(request).Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            if (response.IsSuccessStatusCode)
            {
                var readData = response.Content.ReadAsStringAsync().Result;
                reviews = JsonConvert.DeserializeObject<List<ReviewModel>>(readData);
                return reviews;
            }
            return null;
        }

        public static List<ReviewModel> ListAllReviews()
        {
            List<ReviewModel> reviews = new List<ReviewModel>();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Review/ListAllReviews"),
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
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Review/CreateReview"),
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
        public static bool UpdateReview(ReviewApiModel review)
        {
            var content = JsonConvert.SerializeObject(review, Formatting.Indented);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Review/UpdateReview"),
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
        public static bool DeleteReview(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Review/DeleteReview?id={id}"),
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

    }
}
