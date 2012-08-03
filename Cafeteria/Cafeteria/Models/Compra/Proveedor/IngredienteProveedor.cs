using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cafeteria.Models;
using System.ComponentModel.DataAnnotations;

namespace cafeteria.Models.Compra.Proveedor
{
    public class IngredienteProveedor:IngredienteBean
    {
        
        [RegularExpression("([0-9]+)", ErrorMessage = "El valor ingresado es incorrecto")]
        public decimal precio { get; set; }
        public bool Estado { get; set; }

    }
}