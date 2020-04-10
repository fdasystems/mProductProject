using MVCWebAPIProducts.Entities.DTOs.RequestDto;
using MVCWebAPIProducts.Entities.DTOs.ResponseDto;
using MVCWebAPIProducts.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Services.Interfaces
{
  public interface IProductServices
  {
    IQueryable<Productos> GetProducts();
//    IQueryable<Productos>
      List<Productos> GetProductosPaginationSearchOrderBy(RequestPageDTO requestPage, ref ResponsePaginationMetaDataDTO paginationMetadata);

  }
}
