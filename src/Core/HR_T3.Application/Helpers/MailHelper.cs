using System.Net;
using System.Net.Mail;

namespace HR_T3.Application.Helpers
{
    public class MailHelper
    {
        public static void MailSender(string body, string toMail)
        {
            var fromAddress = new MailAddress("hr3teams@gmail.com");
            var toAddress = new MailAddress(toMail);
            const string subject = "hr3teams şifre bilgisi";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "ssrktjovlzqikoln")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }

        public static string GenerateMailAddress(string name, string midName, string surName, string lastSurName)
        {
            return string.Join("",
                    StringHelpers.ToEnglishChar(name).ToLower(),
                    StringHelpers.ToEnglishChar(midName).ToLower(),
                    ".",
                    StringHelpers.ToEnglishChar(surName).ToLower(),
                    StringHelpers.ToEnglishChar(lastSurName).ToLower(),
                    "@bilgeadamboost.com"
                    );
        }
    }
}
