using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

using System.Data;
using log4net;

namespace Cafeteria.Models
{
    public class Ingredientedao
    {
        String cadenaDB = WebConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        private static ILog log = LogManager.GetLogger(typeof(BaseDatos));

        public List<IngredienteBean> ListarIngrediente(string nombre)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                List<IngredienteBean> ListaIngre = new List<IngredienteBean>();
                objDB.Open();
                String strQuery = "SELECT * FROM Ingrediente";
                if (!String.IsNullOrEmpty(nombre)) strQuery = strQuery + " WHERE UPPER(nombre) LIKE '%" + nombre.ToUpper() + "%'";
                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                SqlDataReader objDataReader = objQuery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                   while (objDataReader.Read())
                   {
                        IngredienteBean ingrediente = new IngredienteBean();
                        ingrediente.ID = Convert.ToString(objDataReader[0]);//muy importante llenar este campo
                        ingrediente.nombre = Convert.ToString(objDataReader[1]);
                        ingrediente.descripcion = Convert.ToString(objDataReader[2]);
                        ingrediente.estado = Convert.ToString(objDataReader[3]);    
                        ListaIngre.Add(ingrediente);
                   }
                }

                return ListaIngre;
             }
             catch (Exception e)
             {
                log.Error("ListaIngredientes(EXCEPTION): ", e);
                throw (e);
             }
             finally
             {
                 if (objDB != null)
                 {
                   objDB.Close();
                 }
             }

        }
        public void registraringrediente(IngredienteBean prod)
        {
            SqlConnection objDB = null;
            int i = Utils.cantidad("Ingrediente")+1;
            string ID="INGR00";//8caracteres-4letras-4#
			if (i<10) prod.ID=ID+"0"+Convert.ToString(i);
				else prod.ID=ID+Convert.ToString(i);
			try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "Insert into Ingrediente (idIngrediente,nombre, descripcion, estado) values " +
                                    "(@id,@nombre, @descripcion, @estado)";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@id", prod.ID);
                Utils.agregarParametro(objQuery, "@nombre", prod.nombre);
                Utils.agregarParametro(objQuery, "@descripcion", prod.descripcion);
                Utils.agregarParametro(objQuery, "@estado", prod.estado);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("registrarIngrediente(EXCEPTION): ", e);
            }
            finally
            {
                if (objDB != null)
                {
                    objDB.Close();
                }
            }
        }
        
        public IngredienteBean BuscarIngre(string id)
        {
            
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                IngredienteBean ingrediente = null;

                objDB.Open();
                String strQuery = "SELECT * FROM Hotel WHERE idIngrediente = @ID";
                SqlCommand objquery = new SqlCommand(strQuery, objDB);
                BaseDatos.agregarParametro(objquery, "@ID", id);

                SqlDataReader objDataReader = objquery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    objDataReader.Read();
                    ingrediente = new IngredienteBean();

                    ingrediente.ID = Convert.ToString(objDataReader[0]);//muy importante llenar este campo
                    ingrediente.nombre = Convert.ToString(objDataReader[1]);
                    ingrediente.descripcion = Convert.ToString(objDataReader[2]);
                    ingrediente.estado = Convert.ToString(objDataReader[3]);
                }
                return ingrediente;
            }
            catch (Exception ex)
            {
                log.Error("getIngrediente(EXCEPTION): ", ex);
                throw ex;
            }
            finally
            {
                if (objDB != null)
                {
                    objDB.Close();
                }
            }
           
        }
        public void ActualizarIngre(IngredienteBean ingrediente)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "UPDATE Ingrediente SET nombre=@nombre, descripcion=@descripcion, estado=@estado" +
                                  "WHERE idIngrediente = @id";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@id", ingrediente.ID);
                Utils.agregarParametro(objQuery, "@nombre", ingrediente.nombre);
                Utils.agregarParametro(objQuery, "@descripcion", ingrediente.descripcion);
                Utils.agregarParametro(objQuery, "@estado", ingrediente.estado);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("registrarIngrediente(EXCEPTION): ", e);
            }
            finally
            {
                if (objDB != null)
                {
                    objDB.Close();
                }
            }
        }

        public void EliminarIngrediente(string ID)
        {

        }
    }
}