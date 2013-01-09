using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using log4net;
using System.Data.SqlClient;

namespace Cafeteria.Models.Reportes
{
    public class ReporteDao
    {

        String cadenaDB = WebConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        private static ILog log = LogManager.GetLogger(typeof(BaseDatos));

        #region area de almacen

        public void reportealmacen(string fecha1, string fecha2, string idSucursal)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "UPDATE Ordencompra SET estado=@estado " +
                                  "WHERE idOrdencompra = @id";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                //Utils.agregarParametro(objQuery, "@estado", estado);
                //Utils.agregarParametro(objQuery, "@id", idordencompra);
                objQuery.ExecuteNonQuery();

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

        #endregion


    }
}