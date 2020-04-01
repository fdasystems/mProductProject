using MVCWebAPIProducts.Interfaces;
using MVCWebAPIProducts.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;



namespace MVCWebAPIProducts.Services
{
  public class MailService : IMailService
  {
    private string _smtpClient = Environment.GetEnvironmentVariable("API_SMTPCLIENT");
    private string _smtpPort = Environment.GetEnvironmentVariable("API_SMTPPORT");
    private string _enableSsl = Environment.GetEnvironmentVariable("API_SMTPENABLESSL");
    private string _useDefaultCredentials = Environment.GetEnvironmentVariable("API_SMTPDEFAULTCREDENTIALS");
    private string _userEmail = Environment.GetEnvironmentVariable("API_SMTPUSER");
    private string _userPassword = Environment.GetEnvironmentVariable("API_SMTPPASSWORD");


    public async Task SendMail(EmailModel email)
    {
      string configs = string.Empty;

      try
      {
        MailMessage mailMessage = new MailMessage();
        mailMessage.To.Add(email.To);
        mailMessage.From = new MailAddress(_userEmail, "FDA SINCE API");//email.From
        mailMessage.Subject = email.Subject;
        mailMessage.Body = email.Body;
        mailMessage.IsBodyHtml = false; //false to security or true to design
        SmtpClient smtpClient = new SmtpClient(_smtpClient);//smtp.gmail.com
        smtpClient.UseDefaultCredentials = true; //bool.Parse(_useDefaultCredentials); //true;
        smtpClient.Port = int.Parse(_smtpPort);//587
        smtpClient.EnableSsl = bool.Parse(_enableSsl);//true
        smtpClient.Credentials = new NetworkCredential(_userEmail, _userPassword);//u+p

        configs = smtpClient.UseDefaultCredentials.ToString() + smtpClient.Port.ToString() + smtpClient.EnableSsl.ToString() + smtpClient.Credentials.ToString();

        await smtpClient.SendMailAsync(mailMessage);
      }
      catch (Exception ex)
      {
        string message = ex.InnerException != null ? ex.InnerException.ToString() : string.Empty;
        message += "**CONFIGS**" + configs + "***INTERNVAL***" + _smtpClient + _smtpPort + _useDefaultCredentials + _enableSsl + _userEmail;
        message += "||" + ex.Message.ToString() + "||" + ex.StackTrace.ToString();

        throw new Exception(message);
      }
    }


    //implementar sendgrid Mail

  }
}
