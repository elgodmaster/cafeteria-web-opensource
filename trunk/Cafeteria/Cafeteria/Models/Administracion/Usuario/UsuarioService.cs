﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafeteria.Models.Administracion.Usuario
{
    public class UsuarioService
    {
        UsuarioDao usuarioDao = new UsuarioDao();
        #region usuario
        public List<UsuarioBean> ListarPersonal(string nombre, string dni, string cargo, string sucursal)
        {
            List<UsuarioBean> usu = new List<UsuarioBean>();
            usu = usuarioDao.ListarPersonal(nombre, dni, cargo, sucursal);
            return usu;
        }

        public UsuarioBean buscarusuario(string idusuario)
        {
            UsuarioBean usuario = new UsuarioBean();
            usuario = usuarioDao.buscarusuario(idusuario);
            return usuario;
        }

        public void registrarpersonal(UsuarioBean usuario)
        {

            usuarioDao.registrarpersonal(usuario);
        }

        public void eliminarusuario(string ID)
        {
            usuarioDao.eliminarusuario(ID);


        }

        public void actualizarusuario(UsuarioBean usuario)
        {
            usuarioDao.actualizarusuario(usuario);

        }

        #endregion

        #region perfil

        public List<UsuarioxSucursalBean> ListarPersonalconperfil(string nombre, string dni, string perfil)
        {
            List<UsuarioxSucursalBean> usu = new List<UsuarioxSucursalBean>();
            usu = usuarioDao.ListarPersonalconperfil(nombre, dni, perfil);
            return usu;
        }



        #endregion

        #region login

        public UsuarioBean getLogin(string usuario, string pass)
        {
            return usuarioDao.getLogin(usuario, pass);
        }

        #endregion


    } 
}