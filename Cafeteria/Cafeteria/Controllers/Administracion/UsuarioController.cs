using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cafeteria.Models.Administracion.Usuario;
using log4net;
using Cafeteria.Models;
using System.Web.Security;
using Cafeteria.Models.Administracion;


namespace Cafeteria.Controllers.Administracion
{
    public class UsuarioController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(UsuarioController));
        administracionfacade admifacade = new administracionfacade();


        public ActionResult Index()
        {
            List<UsuarioBean> usuario = admifacade.ListarPersonal("", "", "", "");


            ViewBag.estado = 0;
            return View(usuario);
                       
        }

        #region detalle
        public ActionResult Details(string id)
        {
            UsuarioBean usuario = new UsuarioBean();
            usuario = admifacade.buscarusuario(id);
            return View(usuario);
        }
        #endregion


        #region asignarhorario

        public ActionResult Horario(String id)
        {
            UsuarioBean usuario = new UsuarioBean();
            UsuarioxSucursalBean usua = new UsuarioxSucursalBean();
            usuario = admifacade.buscarusuario(id);
            usua.ID = usuario.ID;
            usua.nroDocumento = usuario.nroDocumento;
            usua.nombres = usuario.nombres +" "+ usuario.apPat + " "+usuario.apMat;
            usua.dia = new List<string>();
            usua.horafin = new List<DateTime>();
            usua.horainicio = new List<DateTime>();
            usua.dia.Add("Lunes");
            usua.dia.Add("Martes");
            usua.dia.Add("Miercoles");
            usua.dia.Add("Jueves");
            usua.dia.Add("Viernes");
            usua.dia.Add("Sabado");
            usua.dia.Add("Domingo");
            
            return View(usua);
        }

        [HttpPost]
        public ActionResult Horario(UsuarioxSucursalBean usuario)
        {
            
            return View();
        }
        #endregion


        #region Crear
        public ActionResult Create()
        {
            var usuarioVMC = new UsuarioBean();
            try
            {
                usuarioVMC.Departamentos = Utils.listarDepartamentos();
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
                usuario.estado = "ACTIVO";
                List<UsuarioBean> usuarios = admifacade.ListarPersonal("", usuario.nroDocumento, "", "");
                if (usuarios.Count > 0)
                {
                    ViewBag.error = "El Usuario ya existe";
                    return View(usuario);
                }
                else
                {
                    admifacade.registrarpersonal(usuario);
                    return RedirectToAction("Index");
                }
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                log.Error("Create - POST(EXCEPTION): ", ex);
                ModelState.AddModelError("", ex.Message);
                return View(usuario);
                //return View();
            }
        }
        #endregion

        #region editar
        public ActionResult Edit(string id)
        {
            UsuarioBean usuario = new UsuarioBean();
            usuario = admifacade.buscarusuario(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Edit(UsuarioBean usuario)
        {
            try
            {
                //guardar modificaciones
                admifacade.actualizarusuario(usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        
                
        #region Buscar

        public ActionResult Buscar()
        {
            List<UsuarioBean> prod = admifacade.ListarPersonal("", "","", "");


            ViewBag.estado = 0;
            return View(prod);
        }

        [HttpPost]
        public ActionResult Buscar(string nombre, string cargo, string dni, string sucursal)
        {
            ViewBag.estado = 1;
            return View(admifacade.ListarPersonal(nombre, cargo, dni, sucursal));
        }

        #endregion


        #region Eliminar
        public ActionResult Delete(string ID)
        {
            return View(admifacade.buscarusuario(ID));
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(string ID)
        {
            admifacade.eliminarusuario(ID);
            //comprasfacade.EliminarProveedor(ID);
            return Json(new { me = "" });
        }
        #endregion







        #region AdministrarPerfil

        public ActionResult AdministrarPerfil()
        {
            List<UsuarioBean> usua = admifacade.ListarPersonal("", "", "", "");

            ViewBag.estado = 0;

            return View(usua);
        }

        [HttpPost]
        public ActionResult AdministrarPerfil(string id)
        {
            return View();
        }

        #endregion


        #region asignarpersonalaSucursal

        public ActionResult AsignarpersonalSucursal()
        {

            return View();
        }

        #endregion
        /*login----------------------------->>>*/
        #region Login

        [HttpPost]
        public JsonResult LoginResult(String user, String password)
        {
            var usuario = "jose";// usuarioFac.getLogin(user, password);
            if (usuario != null && !usuario.Equals("ONLINE"))
            {
                FormsAuthentication.SetAuthCookie(user, false);
                //usuarioFac.marcarOnline(usuario.ID);
            }
            return new JsonResult() { Data = usuario };
        }

        #endregion

    }
}
