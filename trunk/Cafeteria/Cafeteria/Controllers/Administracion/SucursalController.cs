using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cafeteria.Models;
using Cafeteria.Models.Administracion.Sucursal;
using log4net;
using Cafeteria.Models.Administracion;

namespace Cafeteria.Controllers.Administracion
{
    public class SucursalController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(SucursalController));
        administracionfacade admin = new administracionfacade();
        
        #region Crear
        public ActionResult Create()
        {
            var sucursal = new SucursalBean();
            try
            {
                sucursal.Departamentos = Utils.listarDepartamentos();
                return View(sucursal);
            }
            catch (Exception ex)
            {
                log.Error("Create - GET(EXCEPTION): ", ex);
                ModelState.AddModelError("", ex.Message);
                return View(sucursal);
            }
        }

        [HttpPost]
        public ActionResult Create(SucursalBean suc)
        {
            try
            {
                //registrar a la base 
                admin.registrarSucursal(suc);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        public ActionResult Index()
        {
            List<SucursalBean> suc=admin.listasucursal();
            return View(suc);
        }


    }
}
