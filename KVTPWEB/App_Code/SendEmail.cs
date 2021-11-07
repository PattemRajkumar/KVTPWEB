using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
/// <summary>
/// Summary description for SendEmail
/// </summary>
public class SendEmail
{
    public static void SendMail(string To, string body, string subject)
    {

        MailMessage msg = new MailMessage();
        MailMessage mail = new MailMessage();
        mail.To.Add(To);
        mail.From = new MailAddress("kanavisanjeev@gmail.com");
        mail.Subject = subject;
        string Body = body;
        mail.Body = Body;
        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.UseDefaultCredentials = true;
        smtp.EnableSsl = true;
        smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
        smtp.Port = 587;
       
        smtp.Credentials = new System.Net.NetworkCredential("kanavisanjeev@gmail.com", "******");

        //Or your Smtp Email ID and Password
        
        smtp.Send(mail);
    }
}