using MVCWebAPIProducts.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Xml.Linq;

using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;



namespace MVCWebAPIProducts.Controllers
{
  //   [EnableCors(origins: "*", headers: "*", methods: "*")]http://fdasystems.github.io,
  [EnableCors(origins: "https://fdasystems.github.io,http://localhost:4200", headers: "*", methods: "*", exposedHeaders: "X-Pagination, X-Message")]
  public class ProductsController : ApiController
  {

    //ConfigurationManager.ConnectionStrings["SiSistemasWebEntities"].ConnectionString.ToString()
    //    private SiSistemasWebEntities db = new SiSistemasWebEntities(ConfigurationManager.ConnectionStrings["SiSistemasWebEntities"].ConnectionString.ToString());

    //private SiSistemasWebEntities db = new SiSistemasWebEntities(ConfigurationManager.ConnectionStrings["SiSistemasWebEntitiesDinamic"].ConnectionString.ToString());
    //private SiSistemasWebEntities db = new SiSistemasWebEntities(Environment.GetEnvironmentVariable("SiSistemasWebEntities
    //OK2//
    private SiSistemasWebEntities db = new SiSistemasWebEntities(GenerateConnectionStringEntity(Environment.GetEnvironmentVariable("SiSistemasWebEntitiesSQLSIMPLEMODE")));
    // GET: api/Productos
    public IQueryable<Productos> GetProductos()
    {
      return db.Productos.Include(x => x.Precios);
    }

    public static string GenerateConnectionStringEntity(string connectString)  //  (string connEntity)
    {

      string connBasic = string.Empty;

      //connBasic = "metadata=res://*/Models.ModelDBSistemasWeb.csdl|res://*/Models.ModelDBSistemasWeb.ssdl|res://*/Models.ModelDBSistemasWeb.msl;provider=System.Data.SqlClient;provider connection string=\"data source=190.105.226.76\\MSSQLSERVER2017;initial catalog=SiSistemasDEMO;persist security info=True;user id=FdaSystems;password=F@vio2020!;MultipleActiveResultSets=True;App=EntityFramework\"";


      //var a = new System.Data.EntityClient.EntityConnectionStringBuilder(connBasic);

      //return connBasic;

      // Initialize the SqlConnectionStringBuilder.  
      string dbServer = string.Empty;
      string dbName = string.Empty;
      // use it from previously built normal connection string  
     // string connectString = Convert.ToString(ConfigurationManager.ConnectionStrings[connEntity]);
      var sqlBuilder = new SqlConnectionStringBuilder(connectString);
      // Set the properties for the data source.  
      dbServer = sqlBuilder.DataSource;
      dbName = sqlBuilder.InitialCatalog;
      //sqlBuilder.UserID = "Database_User_ID";
      //sqlBuilder.Password = "Database_User_Password";
      sqlBuilder.IntegratedSecurity = false;
      sqlBuilder.MultipleActiveResultSets = true;
      // Build the SqlConnection connection string.  
      string providerString = Convert.ToString(sqlBuilder);
      // Initialize the EntityConnectionStringBuilder.  
      var entityBuilder = new EntityConnectionStringBuilder();
      //Set the provider name.  
      entityBuilder.Provider = "System.Data.SqlClient";
      // Set the provider-specific connection string.  
      entityBuilder.ProviderConnectionString = providerString;
      // Set the Metadata location.  
      //entityBuilder.Metadata = "res://*/EntityDataObjectName.csdl|res: //*/EntityDataObjectName.ssdl|res: //*/EntityDataObjectName.msl";  //@
      entityBuilder.Metadata = "res://*/Models.ModelDBSistemasWeb.csdl|res://*/Models.ModelDBSistemasWeb.ssdl|res://*/Models.ModelDBSistemasWeb.msl"; // ";" in or out
        return entityBuilder.ToString();

      /*OK*/ //connBasic = "metadata="+entityBuilder.Metadata +"; provider="+ entityBuilder.Provider + ";provider connection string=\"" + providerString + "App=EntityFramework\"";
     /*OK2*/ //connBasic = "metadata=res://*/Models.ModelDBSistemasWeb.csdl|res://*/Models.ModelDBSistemasWeb.ssdl|res://*/Models.ModelDBSistemasWeb.msl;provider=System.Data.SqlClient;provider connection string=\""+ providerString + "App=EntityFramework\"";
     /*OK3*/ //connBasic = "metadata=res://*/Models.ModelDBSistemasWeb.csdl|res://*/Models.ModelDBSistemasWeb.ssdl|res://*/Models.ModelDBSistemasWeb.msl;provider=System.Data.SqlClient;provider connection string=\"data source="+ sqlBuilder.DataSource + ";initial catalog="+ sqlBuilder.InitialCatalog + ";persist security info=True;user id="+ sqlBuilder.UserID + ";password="+sqlBuilder.Password+";MultipleActiveResultSets=True;App=EntityFramework\"";
     // connBasic = "metadata=res://*/Models.ModelDBSistemasWeb.csdl|res://*/Models.ModelDBSistemasWeb.ssdl|res://*/Models.ModelDBSistemasWeb.msl;provider=System.Data.SqlClient;provider connection string=\"data source=190.105.226.76\\MSSQLSERVER2017;initial catalog=SiSistemasDEMO;persist security info=True;user id=FdaSystems;password=F@vio2020!;MultipleActiveResultSets=True;App=EntityFramework\"";

     // return connBasic;
    }


    [ResponseType(typeof(Productos))]
    //[System.Web.Http.HttpGet]             //el proximo paso es tomarlo por [FromQuery] OwnerParameters ownerParameters   (definir el ownerParameter para mi caso)
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
        HttpContext.Current.Response.Headers.Add("X-Message", message.Substring(0,250));
        throw new Exception(message);
      }
      
      return allItemSelected;

      /*//return Ok(allItemSelected);
      return Ok(new
      {
          value = allItemSelected,
          totalPages =  totalPages
      }); */
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

      HttpContext.Current.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

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


    /*
    [HttpGet(Name = nameof(GetProductosPaginationAdvanced))]
    public ActionResult GetProductosPaginationAdvanced([FromQuery]QueryParameters queryParameters)
    {
        var allItemCount = db.Productos.Count();

        var paginationMetadata = new
        {
            totalCount = allItemCount,
            pageSize = queryParameters.PageCount,
            currentPage = queryParameters.Page,
            totalPages = queryParameters.GetTotalPages(allItemCount)
        };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
        var links = CreateLinksForCollection(queryParameters, allItemCount);

        var allItemSelected = db.Productos.Include(x => x.Precios).OrderBy(x => x.Id)
                                .Skip((numberPage - 1) * takeCount)
                                .Take(takeCount);

        var toReturn = allItemSelected; //.Select(x => ExpandSingleItem(x));

        return Ok(new
        {
            value = toReturn,
            links = links
        });
    }
    */


    /*  Modo con repository
    var allItemCount = _customerRepository.Count();

    var paginationMetadata = new
    {
        totalCount = allItemCount,
        pageSize = queryParameters.PageCount,
        currentPage = queryParameters.Page,
        totalPages = queryParameters.GetTotalPages(allItemCount)
    };

    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

    var links = CreateLinksForCollection(queryParameters, allItemCount);

    var toReturn = allCustomers.Select(x => ExpandSingleItem(x));
    */




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
  }
}
