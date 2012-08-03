using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models.Compra;
using Cafeteria.Models;
using Cafeteria.Models.Compra.Proveedor;

namespace Cafeteria.Controllers.Compras
{
    public class ProveedorController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(IngredienteController));
        comprasfacade comprasfacade = new comprasfacade();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            return View();
        }

        #region Buscar
        public ActionResult Buscar()
        {
            List<ProveedorBean> prod = comprasfacade.ListarProveedor("", "");


            ViewBag.estado = 0;
            return View(prod);
        }

        [HttpPost]
        public ActionResult Buscar(string nombre, string ID_tipo)
        {
            ViewBag.estado = 1;
            return View(comprasfacade.ListarProveedor(nombre, ID_tipo));
        }

        #endregion

        #region Registrar

        public ActionResult RegistrarProveedor()
        {
            return View();
        } 


        [HttpPost]
        public ActionResult RegistrarProveedor(ProveedorBean prov)
        {
            try
            {

                List<ProveedorBean> listprov = new List<ProveedorBean>();
                listprov = comprasfacade.ListarProveedor(prov.razonSocial,prov.ruc);

                if (listprov.Count > 0)
                {
                    ViewBag.error = "El Proveedor ya existe";
                    return View(prov);
                }
                else
                {
                    comprasfacade.RegistrarProveedor(prov);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception e)
            {
                log.Error("Create - GET(EXCEPTION):", e);
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        #endregion

        #region editar
        public ActionResult Edit(string id)
        {
            ProveedorBean Producto = comprasfacade.BuscarProveedor(id);
            return View(Producto);
        }

        [HttpPost]
        public ActionResult Edit(ProveedorBean Proveedor)
        {
            try
            {
                comprasfacade.ActualizarProve(Proveedor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region eliminar
        public ActionResult Delete(string ID)
        {
            return View(comprasfacade.BuscarProveedor(ID));
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(string ID)
        {
            comprasfacade.EliminarProveedor(ID);
            return Json(new { me = "" });
        }

        #endregion

    }
}
