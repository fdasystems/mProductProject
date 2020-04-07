using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebAPIProducts.Entities.DTOs.ResponseDto
{
  public class ResponseProductDTO
  {
    public int Id { get; set; }   //probable de no enviar
    public System.DateTime FAlta { get; set; }
    public Nullable<System.DateTime> FBaja { get; set; }
    public string Nombre { get; set; } //probable de quitar por solicitud
    public string Descripcion { get; set; }
    public string Codigo { get; set; }
    public string RutaImagen { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ResponsePriceDTO> Precios { get; set; }
  }
}
