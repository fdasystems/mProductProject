using MVCWebAPIProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MVCWebAPIProducts.Interfaces
{
  public interface IMailService
  {
    Task SendMail(EmailModel email);
  }
}
