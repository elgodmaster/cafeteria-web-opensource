using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models;

namespace Cafeteria.Controllers.Venta
{
    public class ReporteventaController : Controller
    {

        private static ILog log = LogManager.GetLogger(typeof(ReporteventaController));

        public ActionResult filtro()
        {
            Reporte reporte = new Reporte();
            return View(reporte);
        }
        public ActionResult Resultado(string idSucursal, string fecha1, string fecha2,string monto1,string monto2)
        {
            return View();
        }



    }
}
