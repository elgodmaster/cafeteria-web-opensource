using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using log4net;

namespace Cafeteria.Models.Compra.Ordencompra
{
    public class OrdencompraDao
    {
        String cadenaDB = WebConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        private static ILog log = LogManager.GetLogger(typeof(BaseDatos));


        #region Ordencompra
        public string obteneralmacen(string idsucursal)
        {
            string idalmacen = "";

            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "SELECT * FROM Almacen WHERE idCafeteria = @ID";
                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                BaseDatos.agregarParametro(objQuery, "@ID", idsucursal);

                SqlDataReader objDataReader = objQuery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    while (objDataReader.Read())
                    {
                        idalmacen =Convert.ToString(objDataReader["idAlmacen"]);

                    }
                }

                return idalmacen;
            }
            catch (Exception e)
            {
                log.Error("getalmacen(EXCEPTION):  ", e);
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

        public void GuardarOrdenCompra(OrdenProducto producto)
        {



            int cantidad = 0;
            for (int i = 0; i < producto.listaProducto.Count; i++)
            {
                if (producto.listaProducto[i].estadoguardar) cantidad++;
            }
            try
            {
                if (cantidad > 0)
                {
                    String cadenaConfiguracion = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

                    SqlConnection sqlCon = new SqlConnection(cadenaConfiguracion);
                    sqlCon.Open();

                    decimal total = 0; // decimal

                    for (int i = 0; i < producto.listaProducto.Count; i++)
                    {
                        if (producto.listaProducto[i].estadoguardar)
                        {
                            int valor = producto.listaProducto.ElementAt(i).cantidad;
                            decimal precio = producto.listaProducto.ElementAt(i).precio; // decimal
                            total += (valor * precio);
                        }
                    }

                    string commandString = "INSERT INTO OrdenCompra (fechaemitida, estado, precioTotal, idProveedor, idSucursal) VALUES (GETDATE(), 'Tramite' , " + total + " , " + producto.idproveedor + "," + producto.idcafeteria + " )";//idproveedor

                    SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);
                    sqlCmd.ExecuteNonQuery();

                    commandString = "SELECT * FROM OrdenCompra";

                    SqlCommand sqlCmd2 = new SqlCommand(commandString, sqlCon);
                    SqlDataReader dataReader = sqlCmd2.ExecuteReader();

                    string id = "";

                    while (dataReader.Read())
                    {
                        id = (String)dataReader["idOrdencompra"];
                    }

                    sqlCon.Close();

                    String cadenaConfiguracion2 = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

                    SqlConnection sqlCon2 = new SqlConnection(cadenaConfiguracion2);
                    sqlCon2.Open();

                    for (int i = 0; i < producto.listaProducto.Count; i++)
                    {
                        if (producto.listaProducto[i].estadoguardar)
                        {
                            decimal precio = 0; // decimal
                            Producto prod = producto.listaProducto.ElementAt(i);
                            precio = (prod.precio * prod.cantidad);
                            commandString = "INSERT INTO OrdenCompraDetalle (idIngrediente,idOrdencompra,cantidad,precio) VALUES ( " + prod.idproducto + " , " + id + " , " + prod.cantidad + " , " + precio + " )";
                            SqlCommand sqlCmd3 = new SqlCommand(commandString, sqlCon2);
                            sqlCmd3.ExecuteNonQuery();
                        }
                    }

                    sqlCon2.Close();
                }

            }
            catch (Exception ex)
            {
                log.Error("GuardarOrdenCompra(EXCEPTION): ", ex);
                throw ex;
            }
        }

        #endregion



    }
}