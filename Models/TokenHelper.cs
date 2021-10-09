using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebForum.Models {
    public static class TokenHelper {
        public static async Task<bool> SendEmail(string userEmail, string confirmationLink, string title) {
            MailMessage mailMessage = new MailMessage {
                From = new MailAddress("karybers1@gmail.com"),
                Subject = $"AlwaysCity Forum - {title}",
                IsBodyHtml = true,
                Body = $"<h2>AlwaysCity Forum</h2><hr><a href=\"{confirmationLink}\">Click this link to confirm your account</a>"
            };
            mailMessage.To.Add(new MailAddress(userEmail));

            SmtpClient client = new SmtpClient {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(SecretData.senderEmail, SecretData.passwordEmail),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = "smtp.gmail.com",
                Port = 587
            };

            try {
                await client.SendMailAsync(mailMessage);
                Console.WriteLine("Email sent");
                return true;
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}