using Microsoft.AspNetCore.Cors.Infrastructure;
using Newtonsoft.Json;
using ProjectFive.Models;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text.Json;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace ProjectFive.AppFunctions
{
    public class AccountApi
    {
        private static HttpClient client = new HttpClient();
        public static AccountModel VerifyAccount(string cipher)
        {

            string decoded = EncryptionCust.DecodeAndDecrypt(cipher);
            
            string username = decoded.Split(':')[0];
            string password = decoded.Split(':')[1];

            var account = new AccountModel();

            Console.WriteLine("sending");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Account/ListAccount?username={username}&password={password}"),
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
            //var content = JsonConvert.SerializeObject(account, Formatting.Indented);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var content = System.Text.Json.JsonSerializer.Serialize(account, options);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Account/CreateAccount"),
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
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Account/GetUsername?email={email}"),
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
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Account/CreateCode?code={code}&email={email}"),
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
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Account/VerifyCode?code={code}&email={email}"),
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
                RequestUri = new Uri($"http://cis-iis2.temple.edu/Fall2023/CIS3342_tui95333/TermProjectAPI/Account/ForgotAccount?email={email}&newPassword={newPassword}"),
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
