using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using log4net;
using System.Data.SqlClient;

namespace Cafeteria.Models.Venta.Venta
{
    public class VentaDao
    {
        String cadenaDB = WebConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        private static ILog log = LogManager.GetLogger(typeof(BaseDatos));

        public List<VentaBean> buscarventas(string fecha, string idsucursal)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                List<VentaBean> Listadeventas = new List<VentaBean>();
                VentaBean venta = new VentaBean();
                objDB.Open();
                String strQuery = "SELECT * FROM Venta";
                if (!String.IsNullOrEmpty(fecha)) strQuery = "SELECT * FROM Venta WHERE UPPER(fechaventa) LIKE '%" + fecha.ToUpper() + "%'";
                if (!String.IsNullOrEmpty(idsucursal))
                {
                    if (idsucursal != "SUCU0000") strQuery = strQuery + " WHERE UPPER(idCafeteria) LIKE '%" + idsucursal.ToUpper() + "%'";

                }
                if (!String.IsNullOrEmpty(idsucursal) && !String.IsNullOrEmpty(fecha)) strQuery = strQuery + " WHERE UPPER(idCafeteria) LIKE '%" + idsucursal.ToUpper() + "%'" + " AND UPPER(fechaventa) LIKE '%" + fecha.ToUpper() + "%'";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                SqlDataReader objDataReader = objQuery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    while (objDataReader.Read())
                    {
                        venta = new VentaBean();
                        venta.idventa = Convert.ToString(objDataReader["idVenta"]);
                        venta.idSucursal = Convert.ToString(objDataReader["idCafeteria"]);
                        venta.fecharegistro = Convert.ToDateTime(objDataReader["fechaventa"]);
                        venta.totalventa = Convert.ToDecimal(objDataReader["montototal"]);
                        venta.nombresucursal = this.getnombre(venta.idSucursal);
                        Listadeventas.Add(venta);
                    }
                }

                return Listadeventas;
            }
            catch (Exception e)
            {
                log.Error("Listar_Ventas_realizadas(EXCEPTION): ", e);
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

        private string getnombre(string idcafeteria)
        {
            string nombre_tipo = null;
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);


                objDB.Open();
                String strQuery = "SELECT (nombre) FROM Cafeteria WHERE idCafeteria = @ID";
                SqlCommand objquery = new SqlCommand(strQuery, objDB);
                BaseDatos.agregarParametro(objquery, "@ID", idcafeteria);

                SqlDataReader objDataReader = objquery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    objDataReader.Read();

                    nombre_tipo = Convert.ToString(objDataReader["nombre"]);

                }
                return nombre_tipo;
            }
            catch (Exception ex)
            {
                log.Error("GetTipo(EXCEPTION): ", ex);
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


        public List<VentaxProductoBean> obtenerlistaproductos(string idSucursal)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                List<VentaxProductoBean> Listadeproductos = new List<VentaxProductoBean>();
                VentaxProductoBean prod = new VentaxProductoBean();
                objDB.Open();
                String strQuery = "SELECT * FROM Cafeteria_x_Producto WHERE UPPER(idCafeteria) LIKE '%" + idSucursal.ToUpper() + "%'"; 

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                SqlDataReader objDataReader = objQuery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    while (objDataReader.Read())
                    {
                        prod = new VentaxProductoBean();
                        prod.id = Convert.ToString(objDataReader["idProducto"]);
                        prod.preciouniario = Convert.ToDecimal(objDataReader["precioventa"]);
                        prod.cantidad = Convert.ToInt32(objDataReader["cantidad"]);
                       
                        Listadeproductos.Add(prod);
                    }
                }

                return Listadeproductos;
            }
            catch (Exception e)
            {
                log.Error("Lista_productos_sucursal(EXCEPTION): ", e);
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


        public void registrarVenta(VentaBean ven)
        {

        }


    }

}