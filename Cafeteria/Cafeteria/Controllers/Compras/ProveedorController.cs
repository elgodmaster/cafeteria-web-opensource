using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models.Compra;
using Cafeteria.Models;
using Cafeteria.Models.Compra.Proveedor;
using cafeteria.Models.Compra.Proveedor;

namespace Cafeteria.Controllers.Compras
{
    public class ProveedorController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(IngredienteController));
        comprasfacade comprasfacade = new comprasfacade();

        #region Proveedor
        public ActionResult Index()
        {
            List<ProveedorBean> prod = comprasfacade.ListarProveedor("", "");
            return View(prod);
            
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
        public ActionResult Buscar(string nombre, string contacto)
        {
            ViewBag.estado = 1;
            return View(comprasfacade.ListarProveedor(nombre, contacto));
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
                Boolean opcion1 = comprasfacade.existe_ruc(prov.ruc);
                Boolean opcion2 = comprasfacade.existe_razonSocial(prov.razonSocial);
                if (opcion1)
                {
                    ViewBag.error1 = "El Proveedor ya existe";
                    return View(prov);
                }
                else
                    if (opcion2)
                    {
                        ViewBag.error2 = "El numero de RUC ya existe";
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

        #endregion

        #region ProveedorxIngrediente

        public ActionResult AsignarIngredientes(string ID)
        {
            ProveedorBean proveedor = comprasfacade.BuscarProveedor(ID);
            List<IngredienteBean> ListIngre = comprasfacade.ListarIngrediente("");
            IngredientexProveedorBean gg = new IngredientexProveedorBean();

            return View(proveedor);
        }

        #endregion

    }
}
