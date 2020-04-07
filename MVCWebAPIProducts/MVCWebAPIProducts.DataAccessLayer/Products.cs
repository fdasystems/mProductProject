using MVCWebAPIProducts.DataAccessLayer.Base;
using MVCWebAPIProducts.Entities.Model;
using System.Linq;
using System.Data.Entity;
using System;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.DataAccessLayer
{
  public class Products : EntityBase
  {

    public IQueryable<Productos> GetProducts()
    {
      var result = db.Productos.Include(x => x.Precios);
      return result;
    }

    /*
    public async Task<IQueryable<Productos>> GetProducts()
    {
      var result = await db.Productos.Include(x => x.Precios);
      return result;
    }*/

    public /*ActionResult*/ IQueryable<Productos> GetProductosPagination(int numberPage, int takeCount, string searchTerms = "")
    {
      int allItemCount = 0;
      IQueryable<Productos> allItemSelected = null;// = new IQueryable<Productos>();
    
      //si vengo por busqueda el totalItemsCount cambia respecto del Count Gral
      try
      {
        if (searchTerms != null && searchTerms.Length > 0)
        {
          allItemSelected = db.Productos.Include(x => x.Precios).Where(x => x.Codigo.Contains(searchTerms)).OrderBy(x => x.Id);//Aca podes recibir el SORT
          allItemCount = allItemSelected.Count();
        }
        else
        {
          allItemCount = db.Productos.Count();
        }

        //En este paso tomo el count y el filtrado si es que hubo (Se incluye el skip y el take)
        allItemSelected = GetItemsToResponse(numberPage, takeCount, allItemCount, allItemSelected);
      }
      catch (Exception ex)
      {

        string message = ex.InnerException != null ? ex.InnerException.ToString() : string.Empty;
        message += "||ex.Message=>" + ex.Message.ToString() + "||ex.StackTrace=>" + ex.StackTrace.ToString();
        //return BadRequest(message);
 //====>>>MIGRAR===>>>       HttpContext.Current.Response.Headers.Add("X-Message", message.Substring(0, 250));
        throw new Exception(message);
      }

      return allItemSelected;
    }

    private IQueryable<Productos> GetItemsToResponse(int numberPage, int takeCount, int allItemCount, IQueryable<Productos> allItemSelected)
    {
      var totalPages = Math.Ceiling(allItemCount / (double)takeCount);


      var paginationMetadata = new
      {
        totalCount = allItemCount,
        pageSize = takeCount, //queryParameters.PageCount,
        currentPage = numberPage, //queryParameters.Page,
        totalPages = totalPages //queryParameters.GetTotalPages(allItemCount)
      };

      //====>>>MIGRAR===>>>     HttpContext.Current.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

      //Si no filtre nada antes tomo toda la base
      if (allItemSelected == null)
      {
        allItemSelected = db.Productos.Include(x => x.Precios).OrderBy(x => x.Id) //Aca podes recibir el SORT
                  .Skip((numberPage - 1) * takeCount)
                  .Take(takeCount);
      }
      else
      {

        //aca depende de cuantos sean los resultados
        if (totalPages > 1)
        {
          allItemSelected = allItemSelected
                  .Skip((numberPage - 1) * takeCount)
                  .Take(takeCount);
        }
        else
        {// aqui tengo que traer toda la primer pagina
          allItemSelected = allItemSelected
                  .Take(takeCount);
        }
      }

      return allItemSelected;
    }




  }
}
