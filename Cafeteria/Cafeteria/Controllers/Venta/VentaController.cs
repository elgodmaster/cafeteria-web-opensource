using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cafeteria.Models.Venta.Venta;
using Cafeteria.Models.Venta;

namespace Cafeteria.Controllers.Venta
{
    public class VentaController : Controller
    {
        ventafacade ventfacade = new ventafacade();

        #region buscarventa
        public ActionResult Buscar()
        {
            VentaBean ventas = new VentaBean();
            List<VentaBean> listadevem = new List<VentaBean>();
            listadevem.Add(ventas);
            @ViewBag.dat = 1;
            return View(listadevem);
        }

        [HttpPost]
        public ActionResult Buscar(string fecha, string idSucursal)
        {
            //VentaBean ventas = new VentaBean();
            List<VentaBean> listadevem = new List<VentaBean>();
            @ViewBag.dat = 0;
            //listadevem.Add(ventas);
            listadevem = ventfacade.buscarventas(fecha, idSucursal);

            return View(listadevem);
        }
        #endregion

        #region registrarventa

        public ActionResult Create()
        {
            VentaBean ventas = new VentaBean();
            return View(ventas);
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        

    }
}
