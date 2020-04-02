using MVCWebAPIProducts.Interfaces;
using MVCWebAPIProducts.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
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
    private string _apiKey = Environment.GetEnvironmentVariable("API_SENDGRID_KEY");


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
        string message = CaptureErrorDetails(configs, ex);

        throw new Exception(message);
      }
    }

    private string CaptureErrorDetails(string configs, Exception ex)
    {
      string message = ex.InnerException != null ? ex.InnerException.ToString() : string.Empty;
      message += "**CONFIGS**" + configs + "***INTERN_VALUES_IF_SMTP***" + _smtpClient + _smtpPort + _useDefaultCredentials + _enableSsl + _userEmail;
      message += "||ex.Message=>" + ex.Message.ToString() + "||ex.StackTrace=>" + ex.StackTrace.ToString();
      return message;
    }

    //implementar sendgrid Mail
    public async Task SendMailSendgrid(EmailModel email)
    {
      string configs = string.Empty;
      try
      {
        configs = "firstsCharsApiKeySendrig"+ _apiKey.Substring(0,5) + "||_apiKey.Length" + _apiKey.Length + "|| From: " + _userEmail;
        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress(_userEmail, "FDA SINCE API SENDGRID");
        var subject = email.Subject;
        var to = new EmailAddress(email.To);
        var plainTextContent = email.Body;
        //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>"; , htmlContent
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, plainTextContent);
        var response = await client.SendEmailAsync(msg);
        if (response.StatusCode != HttpStatusCode.Accepted && response.StatusCode != HttpStatusCode.OK)
        {
          throw new Exception(response.Headers.ToString() + response.StatusCode + "Error while send via Sendgrid service");
        }
      }
      catch (Exception ex)
      {
        string message = CaptureErrorDetails(configs, ex);

        throw new Exception(message);
      }

    }


    

  }
}
