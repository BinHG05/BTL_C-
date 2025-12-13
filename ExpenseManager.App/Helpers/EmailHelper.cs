using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ExpenseManager.App.Helpers
{
    public class EmailHelper
    {
        
        private static readonly string _senderEmail = "tanbeo31102005@gmail.com";
        private static readonly string _appPassword = "vvxyhvuutswayvwm"; 

        public static async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(_senderEmail, _appPassword),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_senderEmail, "Expense Manager Support"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Ném lỗi ra để Service bắt được
                throw new Exception("Không thể gửi email: " + ex.Message);
            }
        }
    }
}