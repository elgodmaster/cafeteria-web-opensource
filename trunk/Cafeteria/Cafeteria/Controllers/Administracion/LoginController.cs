using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cafeteria.Models.Administracion.Login;
using Cafeteria.Models;
using System.Web.Security;

namespace Cafeteria.Controllers.Administracion
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(loginBean loginmodel)
        {
            if (ModelState.IsValid)
            {
                //if (loginmodel.Usuario == "stardust" && loginmodel.Contrasenia == "stardust")
                if (Utils.comprobarLogin(loginmodel.Usuario, loginmodel.Contrasenia))
                {
                    FormsAuthentication.SetAuthCookie(loginmodel.Usuario, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario y/o Constrasenia incorrectos");
                }
            }
            return View();
        }




  
    }
}
