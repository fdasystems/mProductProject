using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using MVCWebAPIProducts.Services;
using MVCWebAPIProducts.Entities.DTOs.ResponseDto;
using MVCWebAPIProducts.Entities.Model;
using MVCWebAPIProducts.Entities.DTOs.RequestDto;
using MVCWebAPIProducts.ConstantsWebApi;
using MVCWebAPIProducts.Services.Interfaces;
using System.Collections.Generic;

namespace MVCWebAPIProducts.Controllers
{
  [EnableCors(origins: Constants.Configs.enableCorsUrls, headers: Constants.Configs.enableCorsHeaders,
    methods: Constants.Configs.enableCorsMethods, exposedHeaders: Constants.Configs.enableCorsExposedHeaders)]
  [RoutePrefix("api/products")]
  public class ProductsController : ApiController
  {
    private IProductServices _productServices;
    public ProductsController(IProductServices productServices)
    {
      this._productServices = productServices;
    }

    // GET: api/GetProducts
    [HttpGet]
    [Route("GetProducts")]
    public IQueryable<Productos> GetProducts()
    {
      var productsDto = _productServices.GetProducts();
      return productsDto;
    }
    
    [ResponseType(typeof(Productos))]
    [HttpGet]
    [Route("GetProductsPagination")]// to avoid  "Multiple actions were found that match the request Web API"
    public List<Productos> GetProductsPagination([FromUri] RequestPageDTO requestPageDTO)
    {
      List<Productos> allItemSelected = null;
      try
      {
        ResponsePaginationMetaDataDTO paginationMetadata = new ResponsePaginationMetaDataDTO();
        allItemSelected = _productServices.GetProductosPaginationSearchOrderBy(
                                                        requestPageDTO,
                                                        ref paginationMetadata 
                                                        );
        
        HttpContext.Current.Response.Headers.Add(Constants.Configs.enableCorsExposedHeadersXPagination, JsonConvert.SerializeObject(paginationMetadata));
      }
      catch (Exception ex)
      {
        HttpContext.Current.Response.Headers.Add(Constants.Configs.enableCorsExposedHeadersXMessage, ex.Message.Substring(0, 250));
        throw new Exception(ex.Message);
      }

      return allItemSelected;

      //Faltantes:
      //3) hacer las pruebas para que no se rompa el funcionamiento actual --ok
      //3.1)(prueba1 con datos directo, si hay tiempo pruebas unitarias.. --ok
      //3.2) ...o al menos una para sacarte el flujo completo)
    }//4) QUiza agregar async await... pero luego de post-deploy
 
    
    

  }
}
