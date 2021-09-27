/*without authentication----> in account setting allow access to less secure apps

/*using System.Net;
using System.Net.Mail;
namespace SendMail
{
    class Program
    {
        static string smtpAddress = "smtp.gmail.com";
        static int portNumber = 587;
        static bool enableSSL = true;
        static string emailFromAddress = "test@gmail.com"; //Sender Email Address  
        static string password = "*****"; //Sender Password  
        static string emailToAddress = "test1@gmail.com"; //Receiver Email Address  
        static string subject = "Hello";
        static string body = "Hello, This is Email sending test using gmail.";
        static void Main(string[] args)
        {
            SendEmail();
        }
        public static void SendEmail()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                    System.Console.Read();
                }
            }
        }
    }
}*/
/* with client authentication ---> generate app password for client authentication*/
using System;
using System.Collections.Generic;
using System.Text;
using EASendMail; //add EASendMail namespace

namespace mysendemail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Set sender email address, please change it to yours
                oMail.From = "test1@gmail.com";
                // Set recipient email address, please change it to yours
                oMail.To = "test@gmail.com";

                // Set email subject
                oMail.Subject = "test email from c# project";
                // Set email body
                oMail.TextBody = "this is a test email sent from c# project, do not reply";

                // SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");

                // User and password for ESMTP authentication
                oServer.User = "test1@gmail.com";
                oServer.Password = "your-app-generated-key";

                // Most mordern SMTP servers require SSL/TLS connection now.
                // ConnectTryTLS means if server supports SSL/TLS, SSL/TLS will be used automatically.
                oServer.ConnectType = SmtpConnectType.ConnectTryTLS;

                // If your SMTP server uses 587 port
                 oServer.Port = 587;

                // If your SMTP server requires SSL/TLS connection on 25/587/465 port
                // oServer.Port = 25; // 25 or 587 or 465
                // oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }
    }
}
