using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cafeteria.Controllers.Administracion
{
    public class LogoutController : Controller
    {
        public ActionResult Index()//int id)
        {
            FormsAuthentication.SignOut();
            //new UsuarioFacade().logout(id);
            return RedirectToAction("Index", "Login");
        }
    }
}
