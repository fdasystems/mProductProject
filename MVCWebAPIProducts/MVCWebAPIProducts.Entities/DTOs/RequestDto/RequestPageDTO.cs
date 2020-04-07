using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Entities.DTOs.RequestDto
{
  public class RequestPageDTO
  {
    public int numberPage { get; set; }
    public int takeCount { get; set; }
    public string searchTerms { get; set; }

  }
}
