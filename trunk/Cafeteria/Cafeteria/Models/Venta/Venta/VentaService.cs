using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafeteria.Models.Venta.Venta
{
    public class VentaService
    {

        VentaDao ventadao = new VentaDao();
        public List<VentaBean> buscarventas(string fecha, string idsucursal)
        {
            return ventadao.buscarventas(fecha, idsucursal);

        }

    }
}