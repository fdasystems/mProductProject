using MVCWebAPIProducts.ConstantsWebApi;
using MVCWebAPIProducts.Entities.DTOs.RequestDto;
using MVCWebAPIProducts.Services.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MVCWebAPIProducts.Controllers
{  
  [EnableCors(origins: Constants.Configs.enableCorsUrls, headers: Constants.Configs.enableCorsHeaders,
    methods: Constants.Configs.enableCorsMethods, exposedHeaders: Constants.Configs.enableCorsExposedHeaders)]
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

      return Ok(Constants.SuccessMessages.Success);
    }

  
  }
}
