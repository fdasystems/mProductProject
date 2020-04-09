using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Entities.DTOs.RequestDto
{
  public class RequestPageDTO
  {
    [Required]
    public int numberPage { get; set; }
    [Required]
    public int takeCount { get; set; }
    public string searchTerms { get; set; }
    public string orderBy { get; set; }
  }
}
