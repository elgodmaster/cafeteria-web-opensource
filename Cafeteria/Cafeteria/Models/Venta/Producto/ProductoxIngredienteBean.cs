using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafeteria.Models.Venta.Producto
{
    public class ProductoxIngredienteBean
    {
        public string IDProducto { get; set; }
        public string Nombre_Producto { get; set; }
        public string tipo { get; set; }
        public List<ProductoxIngrediente> listaIngre { get; set; }

    }
}