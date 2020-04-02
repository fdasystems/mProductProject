using MVCWebAPIProducts.Models;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Interfaces
{
  public interface IMailService
  {
    Task SendMail(EmailModel email);
    Task SendMailSendgrid(EmailModel email);
  }
}
