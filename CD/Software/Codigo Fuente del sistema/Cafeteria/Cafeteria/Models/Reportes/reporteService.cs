using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafeteria.Models.Reportes
{
    public class ReporteService
    {
        ReporteDao reportedao = new ReporteDao();


        #region area de almacen


        public void reportealmacen(string fecha1, string fecha2, string idSucursal)
        {
            reportedao.reportealmacen(fecha1, fecha2, idSucursal);
        }

        #endregion
    }
}