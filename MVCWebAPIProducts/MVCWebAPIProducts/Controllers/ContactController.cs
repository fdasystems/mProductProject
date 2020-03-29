using MVCWebAPIProducts.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MVCWebAPIProducts.Controllers
{
  [EnableCors(origins: "http://fdasystems.github.io, http://localhost:4200", headers: "*", methods: "*", exposedHeaders: "X-Pagination")]

  public class ContactController : ApiController
  {
    private string _smtpClient = Environment.GetEnvironmentVariable("API_SMTPCLIENT");
    private string _smtpPort = Environment.GetEnvironmentVariable("API_SMTPPORT");
    private string _enableSsl = Environment.GetEnvironmentVariable("API_SMTPENABLESSL");
    private string _useDefaultCredentials = Environment.GetEnvironmentVariable("API_SMTPDEFAULTCREDENTIALS");
    private string _userEmail = Environment.GetEnvironmentVariable("API_SMTPUSER");
    private string _userPassword = Environment.GetEnvironmentVariable("API_SMTPPASSWORD");

    //IHttpActionResult
    [HttpPost]
    public async Task<IHttpActionResult> SendMail([FromBody] EmailModel email) //[FromBody]
    {

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }


      MailMessage mailMessage = new MailMessage();
      mailMessage.To.Add(email.To);
      mailMessage.From = new MailAddress(_userEmail, "FDA SINCE API");//email.From
      mailMessage.Subject = email.Subject;
      mailMessage.Body = email.Body;
      mailMessage.IsBodyHtml = false; //false to security or true to design
      _userPassword = _userPassword.Substring(0, 1) == "2" ? _userPassword + "***" : _userPassword; //Especial config
      SmtpClient smtpClient = new SmtpClient(_smtpClient);//smtp.gmail.com
      smtpClient.UseDefaultCredentials = bool.Parse(_useDefaultCredentials); //true;
      smtpClient.Port = int.Parse(_smtpPort);//587
      smtpClient.EnableSsl = bool.Parse(_enableSsl);//true
      smtpClient.Credentials = new NetworkCredential(_userEmail, _userPassword);//u+p
      await smtpClient.SendMailAsync(mailMessage);

      return Ok();
    }

  }
}
