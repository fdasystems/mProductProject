using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Entities.DTOs.ResponseDto
{
  public class ResponsePaginationMetaDataDTO
  {
    public int TotalCount { get; set; }
    public int TakeCount { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
  }
}
