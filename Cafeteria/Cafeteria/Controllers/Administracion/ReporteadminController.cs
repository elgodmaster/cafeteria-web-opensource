using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace Cafeteria.Controllers.Administracion
{
    public class ReporteadminController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(ReporteadminController));

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
