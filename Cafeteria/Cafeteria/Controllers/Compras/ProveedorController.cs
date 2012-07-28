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


        public ActionResult RegistrarProveedor()
        {
            return View();
        } 


        [HttpPost]
        public ActionResult RegistrarProveedor(ProveedorBean prov)
        {
            try
            {

                //IngredienteBean Ingrediente = new IngredienteBean();
                //Ingrediente.nombre = ;
                //Ingrediente.descripcion = descripcion;
                //Ingrediente.estado = "ACTIVO";
                List<ProveedorBean> listprov = new List<ProveedorBean>();
                listprov = comprasfacade.ListarProveedor(prov.razonSocial,prov.ruc);

                if (listprov.Count > 0)
                {
                    ViewBag.error = "El Proveedor ya existe";
                    return View(prov);
                }
                else
                {
                    //comprasfacade.RegistrarIngrediente(Ingrediente);
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
        
 
 
        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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



    }
}
