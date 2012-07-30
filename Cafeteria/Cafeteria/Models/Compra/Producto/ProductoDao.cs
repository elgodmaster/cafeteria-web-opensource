using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using log4net;
using Cafeteria.Models;

namespace cafeteria.Models.Compra.Producto
{
    public class ProductoDao
    {
        String cadenaDB = WebConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        private static ILog log = LogManager.GetLogger(typeof(BaseDatos));

        public List<ProductoBean> ListarProductos(string nombre)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                List<ProductoBean> ListaProductos = new List<ProductoBean>();
                objDB.Open();
                String strQuery = "SELECT * FROM Producto";
                if (!String.IsNullOrEmpty(nombre)) strQuery = strQuery + " WHERE UPPER(nombre) LIKE '%" + nombre.ToUpper() + "%'";
                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                SqlDataReader objDataReader = objQuery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    while (objDataReader.Read())
                    {
                        ProductoBean Producto = new ProductoBean();
                        Producto.ID = Convert.ToString(objDataReader[0]);//muy importante llenar este campo
                        Producto.nombre = Convert.ToString(objDataReader[1]);
                        Producto.descripcion = Convert.ToString(objDataReader[2]);
                        Producto.Tipo = Convert.ToString(objDataReader[3]);
                        Producto.estado = Convert.ToString(objDataReader[4]);
                        ListaProductos.Add(Producto);
                    }
                }

                return ListaProductos;
            }
            catch (Exception e)
            {
                log.Error("Listar Productos(EXCEPTION): ", e);
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
        public void registrarProducto(ProductoBean produ)
        {
            SqlConnection objDB = null;
            int i = Utils.cantidad("Producto") + 1;
            string ID = "PROD00";//8caracteres-4letras-4#
            if (i < 10) produ.ID = ID + "0" + Convert.ToString(i);
            else produ.ID = ID + Convert.ToString(i);
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "Insert into Ingrediente (idIngrediente,nombre, descripcion, tipo, estado) values " +
                                    "(@id,@nombre, @descripcion,@tipo, @estado)";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@id", produ.ID);
                Utils.agregarParametro(objQuery, "@nombre", produ.nombre);
                Utils.agregarParametro(objQuery, "@descripcion", produ.descripcion);
                Utils.agregarParametro(objQuery, "@tipo", produ.Tipo);
                Utils.agregarParametro(objQuery, "@estado", produ.estado);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("RegistrarProducto(EXCEPTION): ", e);
            }
            finally
            {
                if (objDB != null)
                {
                    objDB.Close();
                }
            }
        }

        public ProductoBean BuscarProducto(string id)
        {

            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                ProductoBean Producto = null;

                objDB.Open();
                String strQuery = "SELECT * FROM Producto WHERE idProducto = @ID";
                SqlCommand objquery = new SqlCommand(strQuery, objDB);
                BaseDatos.agregarParametro(objquery, "@ID", id);

                SqlDataReader objDataReader = objquery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    objDataReader.Read();
                    Producto = new ProductoBean();
                    Producto.ID = Convert.ToString(objDataReader[0]);//muy importante llenar este campo
                    Producto.nombre = Convert.ToString(objDataReader[1]);
                    Producto.descripcion = Convert.ToString(objDataReader[2]);
                    Producto.Tipo = Convert.ToString(objDataReader[3]);
                    Producto.estado = Convert.ToString(objDataReader[4]);
                }
                return Producto;
            }
            catch (Exception ex)
            {
                log.Error("getProducto(EXCEPTION): ", ex);
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
        public void ActualizarProducto(ProductoBean produ)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "UPDATE Producto SET nombre=@nombre, descripcion=@descripcion, estado=@estado, tipo=@tipo" +
                                  "WHERE idProducto = @id";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@nombre", produ.nombre);
                Utils.agregarParametro(objQuery, "@descripcion", produ.descripcion);
                Utils.agregarParametro(objQuery, "@estado", produ.estado);
                Utils.agregarParametro(objQuery, "@tipo", produ.Tipo);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("Actualizar_Producto(EXCEPTION): ", e);
            }
            finally
            {
                if (objDB != null)
                {
                    objDB.Close();
                }
            }
        }

        public void EliminarProducto(string ID)
        {
            string estado = "INACTIVO";
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "UPDATE Producto SET estado=@estado " +
                                  "WHERE idProducto = @id";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@estado", estado);
                Utils.agregarParametro(objQuery, "@id", ID);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("EliminarProducto(EXCEPTION): ", e);
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