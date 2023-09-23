using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace social_media_app.Models
{
    public class Service1
    {
        public string SendEmail(string inputEmail, string subject, string body)
        {
            string returnString = "";
            try
            {
                MailMessage email = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";

                // set up the Gmail server
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("socialmediaapp585@gmail.com", "qwng cjlw wyyv ligy");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;

                // draft the email
                MailAddress fromAddress = new MailAddress("socialmediaapp585@gmail.com");
                email.From = fromAddress;
                email.To.Add(inputEmail);
                email.Subject = body;
                email.Body = body;

                smtp.Send(email);

                returnString = "Success! Please check your e-mail.";
            }
            catch (Exception ex)
            {
                returnString = "Error: " + ex.ToString();
            }
            return returnString;
        }
    }
}
