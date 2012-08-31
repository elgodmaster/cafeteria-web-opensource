using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using log4net;
using System.Web.Configuration;
using Cafeteria.Models.Administracion.Ubigeo;

namespace Cafeteria.Models
{
    public class Utils
    {
        public static String cadenaDB = WebConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        private static ILog log = LogManager.GetLogger(typeof(Utils));

        public static void agregarParametro(SqlCommand objQuery, String nombreParametro, object valorParametro)
        {
            try
            {
                SqlParameter objParametro = new SqlParameter();
                objParametro.ParameterName = nombreParametro;
                objParametro.Value = valorParametro ?? DBNull.Value;
                objQuery.Parameters.Add(objParametro);
            }
            catch (Exception ex)
            {
                log.Error("agregarParametro(EXCEPTION): ", ex);
            }
        }

        public static int cantidad(string tabla)
        {
            SqlConnection objDB = null;
			int i = -1;
			try
			{
				objDB = new SqlConnection(cadenaDB);
				objDB.Open();
				String strQuery = "SELECT COUNT(*) from " + tabla;
				SqlCommand objQuery = new SqlCommand(strQuery, objDB);
				SqlDataReader objDataReader = objQuery.ExecuteReader();
				if (objDataReader.HasRows)
				{
					objDataReader.Read();
					i = Convert.ToInt32(objDataReader[0]);
				}
				return i;
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
			return i;
        }

        public static List<Ubigeo.Departamento> listarDepartamentos() {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                List<Ubigeo.Departamento> lstDepartamento = null;

                objDB.Open();
                String strQuery = "SELECT idDepartamento, nombre FROM Departamento";
                SqlCommand objQuery = new SqlCommand(strQuery, objDB);

                SqlDataReader objReader = objQuery.ExecuteReader();

                if (objReader.HasRows)
                {
                    lstDepartamento = new List<Ubigeo.Departamento>();
                    while (objReader.Read())
                    {
                        Ubigeo.Departamento departamento = new Ubigeo.Departamento();

                        departamento.ID = Convert.ToString(objReader[0]);
                        departamento.nombre = Convert.ToString(objReader[1]);

                        lstDepartamento.Add(departamento);
                    }
                    return lstDepartamento;
                }
                return null;
            }
            catch (Exception ex)
            {
                log.Error("listarDepartamentos(EXCEPTION): ", ex);
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

        public static List<Ubigeo.Provincia> listarProvincias(string idDepartamento) {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                List<Ubigeo.Provincia> lstProvincia = null;

                objDB.Open();
                String strQuery = "SELECT idProvincia, nombre FROM Provincia WHERE idDepartamento = @idDepartamento";
                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                agregarParametro(objQuery, "@idDepartamento", idDepartamento);

                SqlDataReader objReader = objQuery.ExecuteReader();

                if (objReader.HasRows)
                {
                    lstProvincia = new List<Ubigeo.Provincia>();
                    while (objReader.Read())
                    {
                        Ubigeo.Provincia provincia = new Ubigeo.Provincia();

                        provincia.ID = (string)(objReader[0]);
                        provincia.nombre = Convert.ToString(objReader[1]);

                        lstProvincia.Add(provincia);
                    }
                    return lstProvincia;
                }
                return null;
            }
            catch (Exception ex)
            {
                log.Error("listarProvincias(EXCEPTION): ", ex);
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

        public static List<Ubigeo.Distrito> listarDistritos(string idDepartamento, string idProvincia)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                List<Ubigeo.Distrito> lstDistrito = null;

                objDB.Open();
                String strQuery = "SELECT idDistrito, nombre FROM Distrito " +
                                    "WHERE idDepartamento = @idDepartamento AND idProvincia = @idProvincia";
                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                agregarParametro(objQuery, "@idDepartamento", idDepartamento);
                agregarParametro(objQuery, "@idProvincia", idProvincia);

                SqlDataReader objReader = objQuery.ExecuteReader();

                if (objReader.HasRows)
                {
                    lstDistrito = new List<Ubigeo.Distrito>();
                    while (objReader.Read())
                    {
                        Ubigeo.Distrito distrito = new Ubigeo.Distrito();

                        distrito.ID = (string)(objReader[0]);
                        distrito.nombre = Convert.ToString(objReader[1]);

                        lstDistrito.Add(distrito);
                    }
                    return lstDistrito;
                }
                return null;
            }
            catch (Exception ex)
            {
                log.Error("listarDistritos(EXCEPTION): ", ex);
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


    }
}