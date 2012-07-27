using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using log4net;
using System.Web.Configuration;

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
    }
}