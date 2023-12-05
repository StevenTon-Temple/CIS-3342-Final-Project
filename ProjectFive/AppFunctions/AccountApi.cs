using Newtonsoft.Json;
using ProjectFive.Models;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

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
                RequestUri = new Uri($"http://localhost:5283/Account/ListAccount?username={username}&password={password}"),
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

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:5283/Account/CreateAccount"),
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

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetAccountUserName(string email)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://localhost:5283/Account/GetUsername?email={email}"),
                Headers =
                {
                    { "Accept", "application/json" }
                }
            };

            var response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var readData = response.Content.ReadAsStringAsync().Result;
                string s = JsonConvert.DeserializeObject<string>(readData);
                return s;
            }
            return null;
        }

        public static bool CreateCodeEntry(int code, string email)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://localhost:5283/Account/CreateCode?code={code}&email={email}"),
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
            else
            {
                return false;
            }
        }

        public static bool VerifyCode(int code, string email)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://localhost:5283/Account/VerifyCode?code={code}&email={email}"),
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
            else
            {
                return false;
            }
        }

        public static AccountModel ForgotAccount(string newPassword, string email)
        {

            var account = new AccountModel();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://localhost:5283/Account/ForgotAccount?email={email}&newPassword={newPassword}"),
                Headers =
                {
                    { "Accept", "application/json" }
                }
            };

            var response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var readData = response.Content.ReadAsStringAsync().Result;
                account = JsonConvert.DeserializeObject<AccountModel>(readData);
                return account;
            }
            return null;
        }
    }
}
