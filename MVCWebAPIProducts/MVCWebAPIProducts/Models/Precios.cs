//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCWebAPIProducts.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Precios
    {
        public int Id { get; set; }
        public System.DateTime FAlta { get; set; }
        public Nullable<System.DateTime> FBaja { get; set; }
        public int ProductoId { get; set; }
        public Nullable<decimal> Utilidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public Nullable<decimal> Tarjeta { get; set; }
    
        public virtual Productos Productos { get; set; }
    }
}
