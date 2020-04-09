using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Entities.DTOs.RequestDto
{
  public class RequestEmailDTO
  {
    //Basic info to send mail
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
  }
}
