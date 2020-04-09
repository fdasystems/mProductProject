using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Entities.DTOs.ResponseDto
{
  public class ResponsePaginationMetaDataDTO
  {
    public int totalCount { get; set; }
    public int takeCount { get; set; }
    public int currentPage { get; set; }
    public int totalPages { get; set; }
  }
}
