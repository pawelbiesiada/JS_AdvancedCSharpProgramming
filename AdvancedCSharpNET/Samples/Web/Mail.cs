using System;
using System.Net.Mail;

namespace AdvancedCSharp.Samples.Web
{
    class Mail
    {
        static void Main()
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.Credentials = new System.Net.NetworkCredential("user", "password");

            try
            { 
                MailMessage mail = new MailMessage("fromEmail@gmail.com", "toEmail@gmail.com");
                mail.Subject = "Test email.";
                mail.Body = "Test email body";
                client.Send(mail);

                Console.WriteLine("Email sent.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            Console.ReadKey();
        }
    }
}
