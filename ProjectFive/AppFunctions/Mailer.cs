using MailKit.Net.Smtp;
using MimeKit;

namespace ProjectFive.AppFunctions
{
    public class Mailer
    {
        private static MimeMessage CreateEmail(string code, string username, string email)
        {
            BodyBuilder builder = new BodyBuilder();

            try
            {
                string pathToFormat = "wwwroot/Templates/EmailTemplate/ForgotEmail.html";
                string finalPath = Path.Combine(Environment.CurrentDirectory, pathToFormat);
                using(StreamReader sourceReader = File.OpenText(finalPath))
                {
                    builder.HtmlBody = sourceReader.ReadToEnd();
                }

                builder.HtmlBody = builder.HtmlBody.Replace("{username}", username);
                builder.HtmlBody = builder.HtmlBody.Replace("{code}", code);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var newMessage = new MimeMessage();
            newMessage.From.Add(MailboxAddress.Parse("hsmvctesting@gmail.com"));
            newMessage.To.Add(MailboxAddress.Parse(email));
            newMessage.Subject = "Forgot Something";
            newMessage.Body = builder.ToMessageBody();

            return newMessage;
        }

        public static void SendMessage(string code, string username, string email)
        {
            var message = CreateEmail(code, username, email);

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("hsmvctesting@gmail.com", "aasidnqtincaasfj");
            smtp.Send(message);
            smtp.Disconnect(true);
        }
    }
}
