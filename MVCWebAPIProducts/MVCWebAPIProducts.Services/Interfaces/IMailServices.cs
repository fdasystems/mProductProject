using MVCWebAPIProducts.Entities.DTOs.RequestDto;
using MVCWebAPIProducts.Entities.Model;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Services.Interfaces
{
  public interface IMailServices
  {
    Task SendMail(RequestEmailDTO requestMailDTO);
    Task SendMailSendgrid(RequestEmailDTO requestMailDTO);
  }
}
