using System;
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

        public void guardarhorario(UsuarioxSucursalBean usuario)
        {
            usuarioDao.guardarhorario(usuario);
        }

        public UsuarioxSucursalBean obtenerhorario(String id)
        {
            return usuarioDao.obtenerhorario(id);
        }

        public string obtenersucursal(string idusua)
        {
            return usuarioDao.obtenersucursal(idusua);
        }


        #endregion

        #region perfil

        public List<UsuarioxSucursalBean> ListarPersonalconperfil(string nombre, string dni, string perfil)
        {
            List<UsuarioxSucursalBean> usu = new List<UsuarioxSucursalBean>();
            List<string> listaidusuarios = usuarioDao.ListarPersonalconperfil(nombre, dni, perfil);
            //bool estado=false;
            List<bool> estados = new List<bool>();

            for (int i = 0; i < listaidusuarios.Count; i++)
            {
                estados.Add(true);
            }

            for (int i = 0; i < listaidusuarios.Count; i++)
            {
                for (int j = i+1; j < listaidusuarios.Count; j++)
                {
                    if (listaidusuarios[i].CompareTo(listaidusuarios[j])==0) { estados[i] = false; }
                }
                
            }
            
            for (int i = 0; i < listaidusuarios.Count; i++)
            {
                if (estados[i])
                {
                    UsuarioBean nuevo = new UsuarioBean();
                    UsuarioxSucursalBean nue = new UsuarioxSucursalBean();
                    nuevo = usuarioDao.buscarusuario(listaidusuarios[i]);


                    nue.ID = nuevo.ID;
                    nue.nombres = nuevo.nombres;
                    nue.apPat = nuevo.apPat;
                    nue.apMat = nuevo.apMat;
                    nue.nroDocumento = nuevo.nroDocumento;
                    nue.perfilesDelUsuario = usuarioDao.Listaperfiles(nue.ID);
                    //nue.perfilesdelusuario = new List<string>();
                    //nue.perfilesdelusuario.Add(perfil);
                    usu.Add(nue);
                }
            }

           

            return usu;
        }

        public List<string> obtenerlistaperfiles(string id)
        {
            return usuarioDao.Listaperfiles(id);
        }

        public List<string> getperfiles()
        {
            return usuarioDao.getperfiles();
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