using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace Cafeteria.Controllers.Compras
{
    public class ReportecompraController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(ReportecompraController));
        
        public ActionResult filtro()
        {

            return View();
        }

        [HttpPost]
        public ActionResult filtro(string parametros)
        {
            return View();
        }

        
    }
}
