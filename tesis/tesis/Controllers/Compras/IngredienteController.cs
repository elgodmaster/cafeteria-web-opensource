using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using tesis.Models.Compra;
using tesis.Models;


namespace tesis.Controllers
{
    public class IngredienteController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(IngredienteController));
        comprasfacade comprasfacade = new comprasfacade();
        
        public ActionResult Index()
        {
            return View(comprasfacade.ListarIngrediente(""));
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(string nombre, string descripcion)//ProductoBean producto)
        {
            try
            {
               IngredienteBean Ingrediente = new IngredienteBean();
               Ingrediente.nombre = nombre;
               Ingrediente.descripcion = descripcion;
               Ingrediente.estado = "ACTIVO";
               List<IngredienteBean> ingred = new List<IngredienteBean>();
               ingred = comprasfacade.ListarIngrediente(Ingrediente.nombre);

               if (ingred.Count > 0)
               {
                   ViewBag.error = "El producto ya existe";
                   return View(Ingrediente);
               }
               else
               {
                   comprasfacade.RegistrarIngrediente(Ingrediente);
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
        #region buscar
        public ActionResult Buscar()
        {
            List<IngredienteBean> prod = new List<IngredienteBean>();
            ViewBag.estado = 0;
            return View(prod);
        }

        [HttpPost]
        public ActionResult Buscar(string nombre) 
        {
            ViewBag.estado = 1;
            return View(comprasfacade.ListarIngrediente(nombre));
        }

        #endregion
        #region editar
        public ActionResult Edit(int id)
        {
            IngredienteBean ingre = comprasfacade.buscaringrediente(id);
            return View(ingre);
        }

        [HttpPost]
        public ActionResult Edit(IngredienteBean ingre)
        {
            try
            {
                comprasfacade.actualizaringre(ingre);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region eliminar
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int ID)
        {
            comprasfacade.eliminarIngrediente(ID);
            return Json(new { me = "" });
        }

        #endregion

    }
}
