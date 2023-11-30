using Newtonsoft.Json;
using ProjectFive.Models;
using System.Security.Cryptography.X509Certificates;

namespace ProjectFive.AppFunctions
{
    public class AccountApi
    {
        private static HttpClient client = new HttpClient();
        public static AccountModel VerifyAccount(string username, string password)
        {
            var account = new AccountModel();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/Project4WS/Account/ListAccount?email={username}&password={password}"),
                Headers =
                {
                    { "Accept", "application/json" }
                }
            };

            var response = client.SendAsync(request).Result;
            if(response.IsSuccessStatusCode)
            {
                var readData = response.Content.ReadAsStringAsync().Result;
                account = JsonConvert.DeserializeObject<AccountModel>(readData);
                return account;
            }
            return null;
        }

        public static bool CreateAccount(AccountApiModel account)
        {
            var content = JsonConvert.SerializeObject(account, Formatting.Indented);
            Console.WriteLine(content);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/Project4WS/Account/CreateAccount"),
                Headers =
                {
                    { "Accept", "application/json" }
                },
                Content = new StringContent(content)
                {
                    Headers=
                    {
                        ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json")
                    }
                }
            };

            var response = client.SendAsync(request).Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            if(response.IsSuccessStatusCode)
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
