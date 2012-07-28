using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using log4net;
using System.Data.SqlClient;

namespace Cafeteria.Models.Compra.Proveedor
{
    public class ProveedorDao
    {
        String cadenaDB = WebConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        private static ILog log = LogManager.GetLogger(typeof(BaseDatos));

        public List<ProveedorBean> ListarProveedor(string nombre, string ruc)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                List<ProveedorBean> ListaIngre = new List<ProveedorBean>();
                objDB.Open();
                String strQuery = "SELECT * FROM Ingrediente";
                if (!String.IsNullOrEmpty(nombre)) strQuery = strQuery + " WHERE UPPER(nombre) LIKE '%" + nombre.ToUpper() + "%'";
                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                SqlDataReader objDataReader = objQuery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                   while (objDataReader.Read())
                   {
                        ProveedorBean ingrediente = new ProveedorBean();
                        ingrediente.ID = Convert.ToString(objDataReader[0]);//muy importante llenar este campo
                        //ingrediente.nombre = Convert.ToString(objDataReader[1]);
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
        public void RegistrarProveedor(ProveedorBean prod)
        {
            SqlConnection objDB = null;
            int i = Utils.cantidad("Proveedor")+1;
            string ID="PROV00";//8caracteres-4letras-4#
			if (i<10) prod.ID=ID+"0"+Convert.ToString(i);
				else prod.ID=ID+Convert.ToString(i);
			try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "Insert into Proveedor (idIngrediente,nombre, descripcion, estado) values " +
                                    "(@id,@nombre, @descripcion, @estado)";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@id", prod.ID);
                //Utils.agregarParametro(objQuery, "@nombre", prod.nombre);
                Utils.agregarParametro(objQuery, "@descripcion", prod.descripcion);
                Utils.agregarParametro(objQuery, "@estado", prod.estado);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("RegistrarProveedor(EXCEPTION): ", e);
            }
            finally
            {
                if (objDB != null)
                {
                    objDB.Close();
                }
            }
        }
        
        public ProveedorBean BuscarProveedor(string id)
        {
            
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                ProveedorBean ingrediente = null;

                objDB.Open();
                String strQuery = "SELECT * FROM Hotel WHERE idIngrediente = @ID";
                SqlCommand objquery = new SqlCommand(strQuery, objDB);
                BaseDatos.agregarParametro(objquery, "@ID", id);

                SqlDataReader objDataReader = objquery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    objDataReader.Read();
                    ingrediente = new ProveedorBean();

                    ingrediente.ID = Convert.ToString(objDataReader[0]);//muy importante llenar este campo
                    //ingrediente.nombre = Convert.ToString(objDataReader[1]);
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
        public void ActualizarProveedor(ProveedorBean ingrediente)
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
                //Utils.agregarParametro(objQuery, "@nombre", ingrediente.nombre);
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

        public void EliminarProveedor(string ID)
        {
        }
    }
}