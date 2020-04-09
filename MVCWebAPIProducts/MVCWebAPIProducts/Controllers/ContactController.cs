using MVCWebAPIProducts.Entities.DTOs.RequestDto;
using MVCWebAPIProducts.Services.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MVCWebAPIProducts.Controllers
{  //  /, http://fdasystems.github.io, 
  [EnableCors(origins: "https://fdasystems.github.io,http://localhost:4200", headers: "*", methods: "*", exposedHeaders: "*")]

  public class ContactController : ApiController
  {
    private IMailServices _mailService;

    public ContactController(IMailServices mailService)
    {
      this._mailService = mailService;
    }

    /* Original _mailService.SendMail - envio desde server SMPT*//* Nueva version _mailService.SendMailSengrid - envio desde  API  --puede cambiarse solo el metodo-- */
    [HttpPost]
    public async Task<IHttpActionResult> SendMail([FromBody] RequestEmailDTO requestMailDTO) 
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        await _mailService.SendMailSendgrid(requestMailDTO);
      }
      catch (Exception ex)
      {
        return Content(HttpStatusCode.InternalServerError, ex.Message);
      }

      return Ok("Succesfully");
    }

  
  }
}
