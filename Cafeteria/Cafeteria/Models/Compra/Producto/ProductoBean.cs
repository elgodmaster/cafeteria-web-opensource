using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cafeteria.Models.Compra.Producto
{
    public class ProductoBean
    {
        public string ID;
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar nombre de Producto")]
        [RegularExpression("^[a-zA-Z áéíóúAÉÍÓÚÑñ]+$", ErrorMessage = "El nombre ingresado no es válido")]
        public string nombre;
        [Display(Name = "Descripción")]
        public string descripcion;
        public string Tipo;
        public string estado;
    }
}