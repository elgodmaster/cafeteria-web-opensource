using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models.Almacen.Ingrediente
{
    public class IngredienteXalmacenBean
    {
        [Display(Name = "Cafeteria")]
        public String Cafeteria { get; set; }
        public String idalmacen { get; set; }
        public String idCafeteria { get; set; }
        public bool estado { get; set; }
        public List<IngredienteAlmacen> listProdalmacen { get; set; }

        //public string conexion { get; set; }
    }
}