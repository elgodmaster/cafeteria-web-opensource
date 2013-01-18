using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models;
using Cafeteria.Models.Reportes;
using ReportManagement;

namespace Cafeteria.Controllers.Almacen
{
    public class ReportealmaController : PdfViewController
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
            List<List<String>> lista = reportefacade.reportealmacen(fecha1, fecha2, idSucursal);
            Reporte reporte = new Reporte();
            reporte.listaalmacen = lista;
            return this.ViewPdf("", "reportefinal", reporte);
            //return View(reporte);
        }




    
    }



}
