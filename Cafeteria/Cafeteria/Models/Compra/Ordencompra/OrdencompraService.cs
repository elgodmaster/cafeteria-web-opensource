using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafeteria.Models.Compra.Ordencompra
{
    public class OrdencompraService
    {

        OrdencompraDao orde= new OrdencompraDao();

        public string obteneralmacen(string idsucursal)
        {
            string gg = "ALma";
            gg = orde.obteneralmacen(idsucursal);
            return gg;
        }

        public void GuardarOrdenCompra(OrdenProducto ord)
        {
            orde.GuardarOrdenCompra(ord);
        }
        

    }
}