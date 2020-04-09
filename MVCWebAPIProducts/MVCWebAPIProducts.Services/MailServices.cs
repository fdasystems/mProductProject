using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MVCWebAPIProducts.Entities.DTOs.RequestDto;
using MVCWebAPIProducts.Entities.Model;
using MVCWebAPIProducts.Services.ConstantsServices;
using MVCWebAPIProducts.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MVCWebAPIProducts.Services
{
  public class MailServices : IMailServices
  {
    private string _smtpClient = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpClient); 
    private string _smtpPort = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpPort);
    private string _enableSsl = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpEnableSSL);
    private string _useDefaultCredentials = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpDefaultCredentials);
    private string _userEmail = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpUser);
    private string _userPassword = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpPassword);
    private string _apiKey = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SendgridKey);


    public async Task SendMail(RequestEmailDTO requestMailDTO)
    {
      string configs = string.Empty;

      try
      {
        EmailModel email = new EmailModel(_userEmail);
        email.To = requestMailDTO.To;
        email.Subject = requestMailDTO.Subject;
        email.Body = requestMailDTO.Body;
        MailMessage mailMessage = new MailMessage();
        mailMessage.To.Add(email.To);
        mailMessage.From = new MailAddress(email.From, email.AliasFrom); 
        mailMessage.Subject = email.Subject;
        mailMessage.Body = email.Body;
        mailMessage.IsBodyHtml = false; //false to security or true to design
        SmtpClient smtpClient = new SmtpClient(_smtpClient);//smtp.gmail.com
        smtpClient.UseDefaultCredentials = true; //bool.Parse(_useDefaultCredentials); //true;
        smtpClient.Port = int.Parse(_smtpPort);//587
        smtpClient.EnableSsl = bool.Parse(_enableSsl);//true
        smtpClient.Credentials = new System.Net.NetworkCredential(_userEmail, _userPassword);//u+p

        configs = smtpClient.UseDefaultCredentials.ToString() + smtpClient.Port.ToString() + smtpClient.EnableSsl.ToString() + smtpClient.Credentials.ToString();

        await smtpClient.SendMailAsync(mailMessage);
      }
      catch (Exception ex)
      {
        string message = CaptureErrorDetails(configs, ex);

        throw new Exception(message);
      }
    }
    //implementar sendgrid Mail
    public async Task SendMailSendgrid(RequestEmailDTO requestMailDTO)
    {
      string configs = string.Empty;
      try
      {
        EmailModel email = new EmailModel(_userEmail, Constants.ApiContactConfigs.AliasFrom);
        email.To = requestMailDTO.To;
        email.Subject = requestMailDTO.Subject;
        email.Body = requestMailDTO.Body;
        
        configs = "firstsCharsApiKeySendrig" + _apiKey.Substring(0, 5) + "||_apiKey.Length" + _apiKey.Length + "|| From: " + _userEmail;
        var client = new SendGridClient(_apiKey);
        EmailAddress from = new EmailAddress(email.From, email.AliasFrom);
        EmailAddress to = new EmailAddress(email.To);
        string subject = email.Subject;
        string plainTextContent = email.Body;
        //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>"; , htmlContent
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, plainTextContent);
        var response = await client.SendEmailAsync(msg);
        if (response.StatusCode != HttpStatusCode.Accepted && response.StatusCode != HttpStatusCode.OK)
        {
          throw new Exception(response.Headers.ToString() + response.StatusCode + Constants.ApiErrorMessages.SendgridError);
        }
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


  }

}
