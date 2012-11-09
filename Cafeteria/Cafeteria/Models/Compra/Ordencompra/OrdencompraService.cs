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

        public decimal obtenerPrecio(string idproducto, string idproveedor)
        {

            return orde.obtenerPrecio( idproducto, idproveedor);
        }

        public List<OrdencompraBean> buscarOrdenescompra(string idprov, string fecha1, string fecha2)
        {
            return orde.buscarOrdenescompra(idprov, fecha1, fecha2);
        }

    }
}