using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cafeteria.Models.Administracion.Usuario;


namespace Cafeteria.Controllers.Administracion
{
    public class UsuarioController : Controller
    {
  
        public ActionResult Index()
        {
            return View();
           
            
            
        }


        public ActionResult Details(string id)
        {
            return View();
        }

        #region Crear
        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(UsuarioBean usuario)
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

        #region editar
        public ActionResult Edit(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(UsuarioBean usuario)
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

        #region Eliminar
        public ActionResult Delete(string ID)
        {
            return View(/*comprasfacade.BuscarProveedor(ID)*/);
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(string ID)
        {
            //comprasfacade.EliminarProveedor(ID);
            return Json(new { me = "" });
        }
        #endregion

        #region Buscar

        public ActionResult Buscar() 
        {

            return View();
        }

        #endregion


    }
}
