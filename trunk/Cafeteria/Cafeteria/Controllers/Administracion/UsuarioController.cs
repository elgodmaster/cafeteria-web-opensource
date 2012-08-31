using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cafeteria.Models.Administracion.Usuario;
using log4net;
using Cafeteria.Models;


namespace Cafeteria.Controllers.Administracion
{
    public class UsuarioController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(UsuarioController));

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
            var usuarioVMC = new UsuarioViewModelCreate();
            try
            {
                usuarioVMC.Departamentos = Utils.listarDepartamentos();
                usuarioVMC.Documentos = new List<TipoDocumento>();
                usuarioVMC.Documentos.Add(new TipoDocumento() { nombre = "DNI" });
                usuarioVMC.Documentos.Add(new TipoDocumento() { nombre = "RUC" });
                usuarioVMC.Documentos.Add(new TipoDocumento() { nombre = "PASAPORTE" });
                usuarioVMC.Documentos.Add(new TipoDocumento() { nombre = "CARNET DE EXTRANJERIA" });
                //usuarioVMC.PerfilesUsuario = new PerfilUsuarioFacade().listarPerfiles();
                return View(usuarioVMC);
            }
            catch (Exception ex)
            {
                log.Error("Create - GET(EXCEPTION): ", ex);
                ModelState.AddModelError("", ex.Message);
                return View(usuarioVMC);
            }
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
