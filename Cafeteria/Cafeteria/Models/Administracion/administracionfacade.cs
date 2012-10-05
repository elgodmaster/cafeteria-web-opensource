using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cafeteria.Models.Administracion.Usuario;

namespace Cafeteria.Models.Administracion
{
    public class administracionfacade
    {

        UsuarioService usuarioService = new UsuarioService();
        #region Personal
        public List<UsuarioBean> ListarPersonal(string nombre, string dni, string cargo, string sucursal)
        {
            List<UsuarioBean> usu = new List<UsuarioBean>();
            usu = usuarioService.ListarPersonal(nombre, dni, cargo, sucursal);
            return usu;
        }

        public UsuarioBean buscarusuario(string idusuario)
        {
            UsuarioBean usuario = new UsuarioBean();
            usuario = usuarioService.buscarusuario(idusuario);
            return usuario;
        }

        public void registrarpersonal(UsuarioBean usuario)
        {
            usuarioService.registrarpersonal(usuario);

        }

        public void eliminarusuario(string ID)
        {
            usuarioService.eliminarusuario(ID);
            
        }

        public void actualizarusuario(UsuarioBean usuario)
        {
            usuarioService.actualizarusuario(usuario);
        }

        
        #endregion
    }
}