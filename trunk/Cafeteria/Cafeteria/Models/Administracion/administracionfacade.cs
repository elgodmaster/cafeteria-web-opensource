using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cafeteria.Models.Administracion.Usuario;
using Cafeteria.Models.Administracion.Sucursal;

namespace Cafeteria.Models.Administracion
{
    public class administracionfacade
    {

        UsuarioService usuarioService = new UsuarioService();
        SucursalService sucursalservice = new SucursalService();

        #region login 

        public UsuarioBean Getlogin(string user, string pass)
        {
            return usuarioService.getLogin(user, pass);
        }

        #endregion

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

        #region perfil

        public List<UsuarioxSucursalBean> ListarPersonalconperfil(string nombre, string dni, string perfil)
        {
            List<UsuarioxSucursalBean> usu = new List<UsuarioxSucursalBean>();
            usu = usuarioService.ListarPersonalconperfil(nombre, dni, perfil);
            return usu;
        }
        


        #endregion

        #region Sucursal

        public void registrarSucursal(SucursalBean suc)
        {
            sucursalservice.registrar(suc);
        }

        public List<SucursalBean> listasucursal()
        {
            List<SucursalBean> sucur = new List<SucursalBean>();
            sucur = sucursalservice.listarsucursal();
            return sucur;
        }

        #endregion

    }
}