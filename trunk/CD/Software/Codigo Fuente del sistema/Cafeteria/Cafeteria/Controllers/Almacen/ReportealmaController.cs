using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models;
using Cafeteria.Models.Reportes;

namespace Cafeteria.Controllers.Almacen
{
    public class ReportealmaController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(ReportealmaController));
        reportefacade reportefacade = new reportefacade();

        public ActionResult filtro()
        {
            Reporte reporte = new Reporte();
            return View(reporte);
        }
        public ActionResult Resultado(string fecha1, string fecha2, string idSucursal)
        {
            reportefacade.reportealmacen(fecha1, fecha2, idSucursal);
            return View();
        }


    
    }



}
