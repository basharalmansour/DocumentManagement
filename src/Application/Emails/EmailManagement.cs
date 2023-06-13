using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Emails;
public class EmailManagement
{
    public async Task Send(string emailSender , string emailReceiver , string subject , string message , string username , string password)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(emailSender);
        mailMessage.To.Add(emailReceiver);
        mailMessage.Subject = subject;
        mailMessage.Body = message;

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(username, password);
        smtpClient.EnableSsl = true;

        try
        {
            smtpClient.Send(mailMessage);
            throw new Exception ("Email Sent Successfully.");
        }
        catch (Exception ex)
        {
            throw new Exception("Error: " + ex.Message);
        }
    }
}
