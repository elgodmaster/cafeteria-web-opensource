using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models;

namespace Cafeteria.Controllers.Compras
{
    public class ReportecompraController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(ReportecompraController));

        public ActionResult filtro()
        {
            Reporte reporte = new Reporte();
            return View(reporte);
        }
        public ActionResult Resultado(string idSucursal, string fecha1, string fecha2, string idproveedor, string monto1, string monto2)
        {
            return View();
        }


        
    }
}
