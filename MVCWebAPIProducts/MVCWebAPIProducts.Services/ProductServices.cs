using MVCWebAPIProducts.DataAccessLayer;
using MVCWebAPIProducts.Entities.DTOs.RequestDto;
using MVCWebAPIProducts.Entities.DTOs.ResponseDto;
using MVCWebAPIProducts.Entities.Model;
using System;
using System.Linq;

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

    public IQueryable<Productos> GetProductosPaginationSearchOrderBy(RequestPageDTO requestPage, ref ResponsePaginationMetaDataDTO paginationMetadata)
    {
      Products daProduct = new Products();
      int allItemCount = 0;
      IQueryable<Productos> allItemSelected = null;

      //si vengo por busqueda el totalItemsCount cambia respecto del Count Gral
      try
      {
        allItemSelected = daProduct.GetProductsWithPaginationDynamic(requestPage, ref allItemCount);

        //deberia armar ResponsePaginationMetaDataDTO y devolver p/ agregar en la cabecera de paginacion (solo falta calc el "pages")
        paginationMetadata = setPaginationMetaData(requestPage, allItemCount);

      }
      catch (Exception ex)
      {
        string message = ex.InnerException != null ? ex.InnerException.ToString() : string.Empty;
        message += "||ex.Message=>" + ex.Message.ToString() + "||ex.StackTrace=>" + ex.StackTrace.ToString();
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



    //el proximo paso es tomarlo por [FromQuery] OwnerParameters ownerParameters int numberPage, int takeCount,  (definir el ownerParameter para mi caso)
    public /*ActionResult*/ IQueryable<Productos> GetProductosPagination(RequestPageDTO requestPage, string searchTerms = "", string orderBy = "")
    {
      Products daProduct = new Products();
      int allItemCount = 0;
      IQueryable<Productos> allItemSelected = null;// = new IQueryable<Productos>();

      //si vengo por busqueda el totalItemsCount cambia respecto del Count Gral
      try
      {
        if (searchTerms != null && searchTerms.Length > 0)
        {
          allItemSelected = daProduct.GetProductsWithSearchTerm(searchTerms, "Id");//Aca podes recibir el SORT
          allItemCount = allItemSelected.Count();
        }
        else
        {
          allItemCount = daProduct.GetProductsCount();
        }

        //En este paso tomo el count y el filtrado si es que hubo (Se incluye el skip y el take)
        allItemSelected = GetItemsToResponse(requestPage, allItemCount, allItemSelected, orderBy);
      }
      catch (Exception ex)
      {

        string message = ex.InnerException != null ? ex.InnerException.ToString() : string.Empty;
        message += "||ex.Message=>" + ex.Message.ToString() + "||ex.StackTrace=>" + ex.StackTrace.ToString();
        //return BadRequest(message);
        // HttpContext.Current.Response.Headers.Add("X-Message", message.Substring(0,250));
        throw new Exception(message);
      }

      return allItemSelected;
    }

    //int numberPage, int takeCount,
    private IQueryable<Productos> GetItemsToResponse(RequestPageDTO requestPage, int allItemCount, IQueryable<Productos> allItemSelected, string orderBy)
    {
      Products daProduct = new Products();
      var totalPages = Math.Ceiling(allItemCount / (double)requestPage.takeCount);


      var paginationMetadata = new
      {
        totalCount = allItemCount,
        pageSize = requestPage.takeCount, //queryParameters.PageCount,
        currentPage = requestPage.numberPage, //queryParameters.Page,
        totalPages = totalPages //queryParameters.GetTotalPages(allItemCount)
      };

      // HttpContext.Current.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

      //Si no filtre nada antes tomo toda la base
      if (allItemSelected == null)
      {
        allItemSelected = daProduct.GetProductsWithPagination(requestPage, ref allItemCount);
      }
      else
      {

        //aca depende de cuantos sean los resultados
        if (totalPages > 1)
        {
          allItemSelected = allItemSelected
                  .Skip((requestPage.numberPage - 1) * requestPage.takeCount)
                  .Take(requestPage.takeCount);
        }
        else
        {// aqui tengo que traer toda la primer pagina
          allItemSelected = allItemSelected
                  .Take(requestPage.takeCount);
        }
      }

      return allItemSelected;
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
