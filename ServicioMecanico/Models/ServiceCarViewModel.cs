using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicioMecanico.Models
{
    public class ServiceCarViewModel
    {
       
        [DisplayName("Id Servicio")]
        public int IdServicesCar { get; set; }

        [Required]
        [DisplayName("Vehiculo")]
        public int IdCar { get; set; }

        [Required]
        [DisplayName("Servicio")]
        public int IdService { get; set; }

        [Required]
        [DisplayName("Fecha")]
        public System.DateTime ServiceDate { get; set; }

        [Required]
        [DisplayName("Precio")]
        public decimal Price { get; set; }

        [DisplayName("Observaciones")]
        public string Observations { get; set; }

        [DisplayName("Dueño")]
        public int IdOwner { get; set; }
        public virtual Car Car { get; set; }
        public virtual Service Service { get; set; }

        public List<SelectListItem> OwnerList { get; set; }
        public List<SelectListItem> CarList { get; set; }
        public List<SelectListItem> ServiceList { get; set; }

    }
}