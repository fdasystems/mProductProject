using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Entities.DTOs.ResponseDto
{
  public class ResponsePriceDTO
  {
    public int Id { get; set; }
    public System.DateTime FAlta { get; set; }
    public Nullable<System.DateTime> FBaja { get; set; } 
    public int ProductoId { get; set; } 
    public Nullable<decimal> Utilidad { get; set; } //probable corte en envio
    public decimal PrecioVenta { get; set; }
    public Nullable<decimal> Tarjeta { get; set; } //probable corte en envio

    public virtual ResponseProductDTO Productos { get; set; }
  }
}
