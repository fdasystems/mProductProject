using MVCWebAPIProducts.Interfaces;
using MVCWebAPIProducts.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MVCWebAPIProducts.Controllers
{  //  /, http://fdasystems.github.io, 
  [EnableCors(origins: "https://fdasystems.github.io,http://localhost:4200", headers: "*", methods: "*", exposedHeaders: "X-Pagination")]

  public class ContactController : ApiController
  {
    private IMailService _mailService;

    public ContactController(IMailService mailService)
    {
      this._mailService = mailService;
    }




    /* Original _mailService.SendMail - envio desde server SMPT*/
      /* Nueva version _mailService.SendMailSengrid - envio desde  API  --puede cambiarse solo el metodo-- */
    [HttpPost]
    public async Task<IHttpActionResult> SendMail([FromBody] EmailModel email) 
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        await _mailService.SendMailSendgrid(email);
      }
      catch (Exception ex)
      {
        return Content(HttpStatusCode.InternalServerError, ex.Message);
      }

      return Ok("Succesfully");
    }

  
  }
}