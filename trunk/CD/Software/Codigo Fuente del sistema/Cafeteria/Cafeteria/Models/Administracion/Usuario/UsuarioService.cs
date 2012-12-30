﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

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
            UsuarioBean usua= new UsuarioBean();
            if(verificar(usuario,pass)){
                return usuarioDao.getLogin(usuario, pass);
            }
            else{
                
                return usua;
            }
        }


        private Boolean verificar(string usuario, string pass){
            String password = usuarioDao.verificar(usuario); //de la base de datos debe estar encriptado
            MD5 md5Hash = MD5.Create();
            //string hash = GetMd5Hash(md5Hash, password);

            if (VerifyMd5Hash(md5Hash, pass, password))
            {
                return true;
            }
            else
            {
                return false; 
            }
            
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


    } 
}