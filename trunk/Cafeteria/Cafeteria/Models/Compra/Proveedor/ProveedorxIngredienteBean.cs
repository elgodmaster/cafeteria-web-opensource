using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models.Compra.Proveedor
{
    public class ProveedorxIngredienteBean
    {
        [Display(Name = "Proveedor")]
        public String nombre_Proveedor { get; set; }
        public string idproveedor { get; set; }
        public List<ProveedorIngrediente> ListadeIngredientesProveedor { get; set; }
    }
}