using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cafeteria.Models.Compra.Proveedor
{
    public class IngredientexProveedorBean
    {
        [Display(Name = "Proveedor")]
        public String nombre_Proveedor { get; set; }
        public string idproveedor { get; set; }
        public List<IngredienteProveedor> ListadeIngredientesProveedor { get; set; }
    }
}