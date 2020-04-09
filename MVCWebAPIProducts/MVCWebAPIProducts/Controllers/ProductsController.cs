//using MVCWebAPIProducts.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Xml.Linq;

using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;
using MVCWebAPIProducts.Services;
using MVCWebAPIProducts.Entities.DTOs.ResponseDto;
using MVCWebAPIProducts.Entities.Model;
using MVCWebAPIProducts.Entities.DTOs.RequestDto;




namespace MVCWebAPIProducts.Controllers
{
  //   [EnableCors(origins: "*", headers: "*", methods: "*")]http://fdasystems.github.io,
  [EnableCors(origins: "https://fdasystems.github.io,http://localhost:4200", headers: "*", methods: "*", exposedHeaders: "X-Pagination, X-Message")]
  [RoutePrefix("api/products")]
  public class ProductsController : ApiController
  {
    // GET: api/GetProducts
    [HttpGet]
    [Route("GetProducts")]
    public IQueryable<Productos> GetProducts()   //luego public IQueryable<ResponseProductDTO> GetProductos()// return db.Productos.Include(x => x.Precios);
    {
      ProductServices service = new ProductServices();
      var productsDto = service.GetProducts();
      return productsDto;
    }
    


    [ResponseType(typeof(Productos))]
    [HttpGet]
    [Route("GetProductsPagination")]// to avoid  "Multiple actions were found that match the request Web API"
                                     /*ActionResult int numberPage, int takeCount, string searchTerms = "", string orderBy= ""    */
    public IQueryable<Productos> GetProductsPagination([FromUri] RequestPageDTO requestPageDTO)
    {
      IQueryable<Productos> allItemSelected = null;
      try
      {
        ProductServices service = new ProductServices();
        ResponsePaginationMetaDataDTO paginationMetadata = new ResponsePaginationMetaDataDTO();
        allItemSelected = service.GetProductosPaginationSearchOrderBy(
                                                        requestPageDTO,
                                                        ref paginationMetadata 
                                                        );

        HttpContext.Current.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
      }
      catch (Exception ex)
      {
        HttpContext.Current.Response.Headers.Add("X-Message", ex.Message.Substring(0, 250));
        throw new Exception(ex.Message);
      }

      return allItemSelected;

      //Faltantes:
      //1) mover el contactMail al service
      //2) crear entidades necesarias para recibir el DTO correcto (liviano) y enviar el DTO completo (full con from)
      //3) hacer las pruebas para que no se rompa el funcionamiento actual 
      //3.1)(prueba1 con datos directo, si hay tiempo pruebas unitarias.. 
      //3.2) ...o al menos una para sacarte el flujo completo)
    }
 
    
    



      /*

    // GET: api/Productos/5
    [ResponseType(typeof(Productos))]
    public IHttpActionResult GetProductos(int id)
    {
      Productos productos = db.Productos.Include(x => x.Precios).FirstOrDefault(y => y.Id == id); // .Find(id);
      if (productos == null)
      {
        return NotFound();
      }

      return Ok(productos);
    }

    // PUT: api/Productos/5
    [ResponseType(typeof(void))]
    public IHttpActionResult PutProductos(int id, Productos productos)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != productos.Id)
      {
        return BadRequest();
      }

      db.Entry(productos).State = EntityState.Modified;

      try
      {
        db.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ProductosExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    // POST: api/Productos
    [ResponseType(typeof(Productos))]
    public IHttpActionResult PostProductos(Productos productos)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      db.Productos.Add(productos);
      db.SaveChanges();

      return CreatedAtRoute("DefaultApi", new { id = productos.Id }, productos);
    }

    // DELETE: api/Productos/5
    [ResponseType(typeof(Productos))]
    public IHttpActionResult DeleteProductos(int id)
    {
      Productos productos = db.Productos.Find(id);
      if (productos == null)
      {
        return NotFound();
      }

      db.Productos.Remove(productos);
      db.SaveChanges();

      return Ok(productos);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool ProductosExists(int id)
    {
      return db.Productos.Count(e => e.Id == id) > 0;
    }

    */

  }
}
