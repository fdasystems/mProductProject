using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MVCWebAPIProducts.Models;
using Newtonsoft.Json;
using System.Web;
using System.Web.Http.Cors;


namespace MVCWebAPIProducts.Controllers
{
    //   [EnableCors(origins: "*", headers: "*", methods: "*")]
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Pagination")]
    public class ProductosController : ApiController
    {
        private SiSistemasWebEntities db = new SiSistemasWebEntities();

        // GET: api/Productos
        public IQueryable<Productos> GetProductos()
        {
            return db.Productos.Include(x => x.Precios);
        }


        
        [ResponseType(typeof(Productos))]
        //[System.Web.Http.HttpGet]
        public /*ActionResult*/ IQueryable<Productos> GetProductosPagination(int numberPage, int takeCount /*, int? allItemCountFromClient*/)
        {
            var allItemCount = db.Productos.Count();
            var totalPages = Math.Ceiling(allItemCount / (double)takeCount);


            var paginationMetadata = new
            {
                totalCount = allItemCount,
                pageSize = takeCount, //queryParameters.PageCount,
                currentPage = numberPage, //queryParameters.Page,
                totalPages = totalPages //queryParameters.GetTotalPages(allItemCount)
            };

            HttpContext.Current.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));


            var allItemSelected = db.Productos.Include(x => x.Precios).OrderBy(x => x.Id)
                .Skip((numberPage - 1) * takeCount)
                .Take(takeCount);

            //return Ok(allItemSelected);
            return allItemSelected;

            /*
            return Ok(new
            {
                value = allItemSelected,
                totalPages =  totalPages
            }); */
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