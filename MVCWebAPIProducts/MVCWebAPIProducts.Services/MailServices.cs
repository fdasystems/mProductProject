using MVCWebAPIProducts.Entities.DTOs.RequestDto;
using MVCWebAPIProducts.Entities.Model;
using MVCWebAPIProducts.Services.ConstantsServices;
using MVCWebAPIProducts.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Services
{
  public class MailServices : IMailServices
  {
    private string _smtpClient = string.Empty;
    private string _smtpPort = string.Empty;
    private string _enableSsl = string.Empty;
    private string _useDefaultCredentials = string.Empty;
    private string _userEmail = string.Empty;
    private string _userPassword = string.Empty;
    private string _apiKey = string.Empty;
    private string _fromAlias = string.Empty;

    public MailServices()
    {
      bool getFromEnviroment = ConfigurationManager.AppSettings[Constants.ApiContactConfigs.GetFromEnviroment] == null ? false :
                            bool.Parse(ConfigurationManager.AppSettings[Constants.ApiContactConfigs.GetFromEnviroment]);
      //check enviroment or webconfig
      if (getFromEnviroment)
      {
        _smtpClient = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpClient);
        _smtpPort = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpPort);
        _enableSsl = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpEnableSSL);
        _useDefaultCredentials = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpDefaultCredentials);
        _userEmail = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpUser);
        _userPassword = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SmtpPassword);
        _apiKey = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.SendgridKey);
        _fromAlias = Environment.GetEnvironmentVariable(Constants.ApiContactConfigs.AliasFrom);
      }
      else
      {
        _smtpClient = ConfigurationManager.AppSettings[Constants.ApiContactConfigs.SmtpClient];
        _smtpPort = ConfigurationManager.AppSettings[Constants.ApiContactConfigs.SmtpPort];
        _enableSsl = ConfigurationManager.AppSettings[Constants.ApiContactConfigs.SmtpEnableSSL];
        _useDefaultCredentials = ConfigurationManager.AppSettings[Constants.ApiContactConfigs.SmtpDefaultCredentials];
        _userEmail = ConfigurationManager.AppSettings[Constants.ApiContactConfigs.SmtpUser];
        _userPassword = ConfigurationManager.AppSettings[Constants.ApiContactConfigs.SmtpPassword];
        _apiKey = ConfigurationManager.AppSettings[Constants.ApiContactConfigs.SendgridKey];
        _fromAlias = ConfigurationManager.AppSettings[Constants.ApiContactConfigs.AliasFrom];
      }
    }

    public async Task SendMail(RequestEmailDTO requestMailDTO)
    {
      string configs = string.Empty;

      try
      {
        EmailModel email = new EmailModel(_userEmail, _fromAlias);
        email.To = requestMailDTO.To;
        email.Subject = requestMailDTO.Subject;
        email.Body = requestMailDTO.Body;
        MailMessage mailMessage = new MailMessage();
        mailMessage.To.Add(email.To);
        mailMessage.From = new MailAddress(email.From, email.AliasFrom);
        mailMessage.Subject = email.Subject;
        mailMessage.Body = email.Body;
        mailMessage.IsBodyHtml = false; //false to security or true to design
        SmtpClient smtpClient = new SmtpClient(_smtpClient);
        smtpClient.UseDefaultCredentials = true;
        smtpClient.Port = int.Parse(_smtpPort);
        smtpClient.EnableSsl = bool.Parse(_enableSsl);
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
        EmailModel email = new EmailModel(_userEmail, _fromAlias)
        {
          To = requestMailDTO.To,
          Subject = requestMailDTO.Subject,
          Body = requestMailDTO.Body
        };

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
      message += Constants.ApiErrorMessages.ExMessageConfigLabel + configs
                + Constants.ApiErrorMessages.ExMessageSmtpLabel + _smtpClient + _smtpPort
                + _useDefaultCredentials + _enableSsl + _userEmail;
      message += Constants.ApiErrorMessages.ExMessageLabel + ex.Message.ToString()
                + Constants.ApiErrorMessages.ExStackLabel + ex.StackTrace.ToString();
      return message;
    }


  }

}
