using academia.Application.Models;
using System.Net.Mail;
using System.Text;

namespace academia.Application.Services
{
    public class EmailServices : EntidadeEmailPasswordAccount
    {
        private const string Smtp = "smtp.gmail.com";
        private const int Port = 587;
        private const string UserEmail = "publicartere@gmail.com";

        public async Task SendEmailAsync(EntidadeEmailAddressModelView entidadeEmailServices)
        {
            try
            {
                using (var msgMail = new MailMessage())
                {
                    msgMail.From = new MailAddress(UserEmail);
                    msgMail.To.Add(entidadeEmailServices.To);
                    msgMail.Subject = entidadeEmailServices.Subject;
                    msgMail.Body = entidadeEmailServices.Body;
                    msgMail.IsBodyHtml = true;
                    msgMail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                    msgMail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.EnableSsl = true;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new System.Net.NetworkCredential(UserEmail, Password);
                        smtpClient.Host = Smtp;
                        smtpClient.Port = Port;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.Timeout = 20_000;
                        await smtpClient.SendMailAsync(msgMail);
                    }
                }
            }
            catch (SmtpException ex)
            {
                throw new Exception($"Erro ao enviar o e-mail {ex.Message}");
            }
        }
    }
}
