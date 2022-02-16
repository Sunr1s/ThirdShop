using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
namespace ThirdShop.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Site administration", "mamadoma22s@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {

                await client.ConnectAsync("smtp.gmail.com", 587, false);
                //client.AuthenticationMechanisms.Remove("XOAUTH2");
               
                await client.AuthenticateAsync("mamadoma22s@gmail.com", "29052003a");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}