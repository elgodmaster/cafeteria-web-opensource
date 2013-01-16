using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models;
using Cafeteria.Models.Reportes;

namespace Cafeteria.Controllers.Compras
{
    public class ReportecompraController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(ReportecompraController));
        reportefacade reportefacade = new reportefacade();
        public ActionResult filtro()
        {
            Reporte reporte = new Reporte();
            return View(reporte);
        }
        public ActionResult Resultado(string idSucursal, string fecha1, string fecha2, string idproveedor, string monto1, string monto2)
        {
            List<List<String>> lista = reportefacade.reportecompras(idSucursal, fecha1, fecha2, idproveedor, monto1, monto2);
            return View();
        }


        
    }
}
