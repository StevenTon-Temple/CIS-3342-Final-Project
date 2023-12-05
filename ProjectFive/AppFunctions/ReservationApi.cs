using Newtonsoft.Json;
using ProjectFive.Models;

namespace ProjectFive.AppFunctions
{
    public class ReservationApi
    {
        private static HttpClient client = new HttpClient();

        public static List<ReservationModel> ListReservations()
        {
            List<ReservationModel> reservations = new List<ReservationModel>();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://localhost:5283/Reservation/ListReservations"),
                Headers =
                {
                    { "Accept", "application/json" }
                }
            };

            var response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var readData = response.Content.ReadAsStringAsync().Result;
                reservations = JsonConvert.DeserializeObject<List<ReservationModel>>(readData);
                return reservations;
            }
            return null;
        }

        public static bool UpdateReservation(ReservationAPIModel reservation)
        {
            var content = JsonConvert.SerializeObject(reservation, Formatting.Indented);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:5283/Reservation/UpdateReservation"),
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

        public static bool DeleteReservation(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://localhost:5283/Reservation/DeleteReservation?id={id}"),
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

        public static bool CreateReservation(ReservationAPIModel reservation)
        {
            var content = JsonConvert.SerializeObject(reservation, Formatting.Indented);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:5283/Reservation/CreateReservation"),
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
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);

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
