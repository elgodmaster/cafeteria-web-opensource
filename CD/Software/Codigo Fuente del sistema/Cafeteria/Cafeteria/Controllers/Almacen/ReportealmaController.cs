using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models;

namespace Cafeteria.Controllers.Almacen
{
    public class ReportealmaController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(ReportealmaController));

        public ActionResult filtro()
        {
            Reporte reporte = new Reporte();
            return View(reporte);
        }
        public ActionResult Resultado(string fecha1, string fecha2, string idSucursal)
        {
            return View();
        }


    
    }



}
