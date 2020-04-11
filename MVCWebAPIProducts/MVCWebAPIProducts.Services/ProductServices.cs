using MVCWebAPIProducts.DataAccessLayer;
using MVCWebAPIProducts.Entities.DTOs.RequestDto;
using MVCWebAPIProducts.Entities.DTOs.ResponseDto;
using MVCWebAPIProducts.Entities.Model;
using MVCWebAPIProducts.Services.ConstantsServices;
using MVCWebAPIProducts.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCWebAPIProducts.Services
{
  public class ProductServices : IProductServices
  {

    //El primer paso pasamos directo las entidades de Entities (la separacion es solo logica)
    public IQueryable<Productos> GetProducts()
    {
      Products daProduct = new Products();
      return daProduct.GetProducts();
    }
    //IQueryable<Productos>
    public List<Productos>  GetProductosPaginationSearchOrderBy(RequestPageDTO requestPage, ref ResponsePaginationMetaDataDTO paginationMetadata)
    {
      Products daProduct = new Products();
      int allItemCount = 0;
      List<Productos> allItemSelected = new List<Productos>();
      //si vengo por busqueda el totalItemsCount cambia respecto del Count Gral
      try
      {
         allItemSelected = daProduct.GetProductsWithPaginationDynamicList(requestPage, ref allItemCount);
        //deberia armar ResponsePaginationMetaDataDTO y devolver p/ agregar en la cabecera de paginacion (solo falta calc el "pages")
        paginationMetadata = setPaginationMetaData(requestPage, allItemCount);
      }
      catch (Exception ex)
      {
        string message = ex.InnerException != null ? ex.InnerException.ToString() : string.Empty;
        message += Constants.ApiErrorMessages.ExMessageConfigLabel + ex.Message.ToString() +
                   Constants.ApiErrorMessages.ExStackLabel + ex.StackTrace.ToString();
        throw new Exception(message);
      }

      return allItemSelected;
    }

    private static ResponsePaginationMetaDataDTO setPaginationMetaData(RequestPageDTO requestPage, int allItemCount)
    {
      ResponsePaginationMetaDataDTO paginationMetadata;
      var totalPages = Math.Ceiling(allItemCount / (double)requestPage.takeCount);


      paginationMetadata = new ResponsePaginationMetaDataDTO()
      {
        totalCount = allItemCount,
        takeCount = requestPage.takeCount,
        currentPage = requestPage.numberPage,
        totalPages = (int)totalPages
      };
      return paginationMetadata;
    }





















    /// <summary>
    /// /*****//Luego de que el BL este correcto trato de enviar los DTO filtrando datos que no necesito
    /// </summary>
    /// <returns></returns>
    public List<ResponseProductDTO> GetProductsDTO()
    {
      Products daProduct = new Products();
      var products = daProduct.GetProducts().ToList();
      //List<ResponseProductDTO> ListResponseProductDTO = products; //este mapper deberia agregarlo
      //IQueryable<ResponseProductDTO>
      List<ResponseProductDTO> ListResponseProductDTO = new List<ResponseProductDTO>();
      foreach (var item in products)
      {
        ResponseProductDTO productDto = new ResponseProductDTO()
        {
          Id = item.Id,
          FAlta = item.FAlta,
          FBaja = item.FBaja,
          Nombre = item.Nombre,
          Descripcion = item.Descripcion,
          Codigo = item.Codigo,
          RutaImagen = item.RutaImagen  /*,   //Ver el mapping correcto el mas complejo es precios
          Precios = new List<ResponsePriceDTO>(){item.Precios;//Id = item.Precios.FirstOrDefault().Id,
            //PrecioVenta = item.Precios.FirstOrDefault().PrecioVenta
          }  */
          //item.PreciosPrecios = item.Precios
        };

        ListResponseProductDTO.Add(productDto);
      }

      return ListResponseProductDTO;
    }

  }
}
