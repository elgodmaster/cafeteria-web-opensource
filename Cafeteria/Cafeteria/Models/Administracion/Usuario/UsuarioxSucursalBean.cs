using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cafeteria.Models.Administracion.Perfil_Usuario;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Configuration;

namespace Cafeteria.Models.Administracion.Usuario
{
    public class Perfiles2
    {
        public string ID { get; set; }
        public string nombre { get; set; }
    }
    
    
    
    public class UsuarioxSucursalBean : UsuarioBean
    {
        public DateTime fechainiciotrabajo { get; set; }
        public DateTime fechaingreso { get; set; }
        public DateTime fechafin { get; set; }
        public string sucursal { get; set; }
        public string cargo { get; set; }
        public List<String> dia { get; set; }
        public List<DateTime> horainicio { get; set; }
        public List<DateTime> horafin { get; set; }

        public string perfil { get; set; }

        public string idperfil { get; set; }

        public List<String> perfilesdelusuario { get; set; }

        public SelectList UsuarioList { get; set; }
        public List<PerfilUsuarioBean> gg { get; set; }

        public IEnumerable<Perfiles2> getperfil()
        {
            List<Perfiles2> listaperfil = new List<Perfiles2>();
            String cadenaDB = WebConfigurationManager.ConnectionStrings["Base"].ConnectionString;


            SqlConnection objDB = new SqlConnection(cadenaDB);
            objDB.Open();

            string commandString = "SELECT * FROM Perfil_usuario ";

            SqlCommand sqlCmd = new SqlCommand(commandString, objDB);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            Perfiles2 perfil2s = new Perfiles2();
            perfil2s.ID = "PERF0000";
            perfil2s.nombre = "Todos";
            listaperfil.Add(perfil2s);

            while (dataReader.Read())
            {
                Perfiles2 perfil = new Perfiles2();
                perfil.ID = Convert.ToString(dataReader["idPerfil_usuario"]);
                perfil.nombre = (string)dataReader["nombre"];

                listaperfil.Add(perfil);
            }
            
            
            return listaperfil;
        }

        public UsuarioxSucursalBean()
        {
            UsuarioList = new SelectList(getperfil(), "ID", "Nombre");
        }

    }

}