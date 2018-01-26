using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace Lyngby_Bryghus.ViewFactories
{
    public class Mailer
    {

        private string _SMTP = "smtp.gmail.com";
        private string _fromUserName = "message@lyngbybryghus"; //e-mailen, der er sat op til at sende beskeden fra brugeren (gmail)
        private string _password = "12345"; //koden til e-mailen ovenover
        private string _toEmail = "ejer@lyngbybryghus.dk"; //firmaets e-mail
        private string _subject = "Besked fra besøgende på Lyngbybryghus.dk"; 
        private int _port = 587;

        public void Send(string businessName, string name, string email, string phoneNumber, string message)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(_fromUserName, _fromUserName);


            mail.To.Add(_toEmail);
            mail.Subject = _subject;
            mail.Body = "<h1>kontakt oplysninger</h1>"
                        + "<h3>Fra: " + businessName + "</h3>"
                        + "<h3>Email: " + name + "</h3>"
                        + "<h3>Email: " + email + "</h3>"
                        + "<h3>Email: " + phoneNumber + "</h3>"
                        + "<hr />"
                        + "<p>" + message + "</p>";
            mail.IsBodyHtml = true;

            SmtpClient smtpCl = new SmtpClient(_SMTP, _port);


            smtpCl.EnableSsl = true;
            smtpCl.UseDefaultCredentials = false;
            smtpCl.Credentials = new NetworkCredential(_fromUserName, _password);
            smtpCl.DeliveryMethod = SmtpDeliveryMethod.Network;


            smtpCl.Send(mail);

        }


    }
}