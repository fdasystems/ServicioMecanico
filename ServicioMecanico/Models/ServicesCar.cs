//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioMecanico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServicesCar
    {
        public int IdServicesCar { get; set; }
        public int IdCar { get; set; }
        public int IdService { get; set; }
        public System.DateTime ServiceDate { get; set; }
        public decimal Price { get; set; }
        public string Observations { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Service Service { get; set; }
    }
}
