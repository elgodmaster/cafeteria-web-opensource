using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models.Administracion.Sucursal
{
    public class SucursalBean
    {
        [Display(Name = "ID")]
        public string id { get; set; }

        [Display(Name = "Razon Social")]
        public string Razonsocial { get; set; }

        [Display(Name = "Ruc")]
        public string ruc { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
        
        [Display(Name = "Teléfono 1")]
        public string telefono1 { get; set; }
        
        [Display(Name = "Teléfono 2")]
        public string telefono2 { get; set; }

        [Display(Name = "Nombre de Administrador")]
        public string nombreadministrador { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Debe elegir un departamento")]
        public string idDepartamento { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Debe elegir un provincia")]
        public string idProvincia { get; set; }

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "Debe elegir un distrito")]
        public string idDistrito { get; set; }

        public List<Ubigeo.Ubigeo.Departamento> Departamentos { get; set; }
    }


}