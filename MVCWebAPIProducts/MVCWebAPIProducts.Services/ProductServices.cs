using MVCWebAPIProducts.DataAccessLayer;
using MVCWebAPIProducts.Entities.DTOs.ResponseDto;
using MVCWebAPIProducts.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Services
{
    public class ProductServices
    {

    //El primer paso pasamos directo las entidades de Entities (la separacion es solo logica)
    public IQueryable<Productos> GetProducts()
    {
      Products daProduct = new Products();
      return daProduct.GetProducts();
    }











    /// <summary>
    /// /*****//Luego de que el BL este correcto trato de enviar los DTO filtrando datos que no necesito
    /// </summary>
    /// <returns></returns>
      public IQueryable<ResponseProductDTO> GetProductsDTO()
    {
      Products daProduct = new Products();
      var products = daProduct.GetProducts();

      return null; //new List<ResponseProductDTO>();  //()products.ToList();
      /*
      ResponseProductDTO productDto = new ResponseProductDTO(
        {
          Codigo = 
        }
        );

      
      var dto = service.GetDto<WebChangeDeliveryDto>(x =>
      {
        x.OrderId = id;
        x.UserId = GetUserId(HttpContext);
      });*/
    }
  }
}
