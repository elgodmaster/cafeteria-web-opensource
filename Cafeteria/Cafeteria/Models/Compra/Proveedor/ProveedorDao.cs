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

        public List<ProveedorBean> ListarProveedor(string RazonSocial, string contacto)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                List<ProveedorBean> ListaIngre = new List<ProveedorBean>();
                objDB.Open();
                String strQuery = "SELECT * FROM Proveedor";
                if (!String.IsNullOrEmpty(RazonSocial)) strQuery = strQuery + " WHERE UPPER(razonSocial) LIKE '%" + RazonSocial.ToUpper() + "%'";
                if (!String.IsNullOrEmpty(contacto)) strQuery = strQuery + " WHERE UPPER(contacto) LIKE '%" + contacto.ToUpper() + "%'";
                if (!String.IsNullOrEmpty(RazonSocial) && !String.IsNullOrEmpty(contacto)) strQuery = strQuery + " WHERE UPPER(razonSocial) LIKE '%" + RazonSocial.ToUpper() + "%'"+
                                                                                            " AND UPPER(contacto) LIKE '%" + contacto.ToUpper() + "%'";
                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                SqlDataReader objDataReader = objQuery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                   while (objDataReader.Read())
                   {
                        ProveedorBean Proveedor = new ProveedorBean();
                        Proveedor.ID = Convert.ToString(objDataReader[0]);
                        Proveedor.razonSocial = Convert.ToString(objDataReader[1]);
                        Proveedor.estado = Convert.ToString(objDataReader[2]);
                        Proveedor.contacto = Convert.ToString(objDataReader[3]);
                        Proveedor.email_contacto = Convert.ToString(objDataReader[4]);
                        Proveedor.direccion = Convert.ToString(objDataReader[5]);
                        Proveedor.ruc = Convert.ToString(objDataReader[6]);
                        Proveedor.telefono1 = Convert.ToString(objDataReader[7]);
                        Proveedor.CargoContacto = Convert.ToString(objDataReader[8]);
                        Proveedor.telefono_contacto = Convert.ToString(objDataReader[9]);
                        Proveedor.web = Convert.ToString(objDataReader[10]);
                        Proveedor.Observacion = Convert.ToString(objDataReader[11]);
                        Proveedor.telefono2 = Convert.ToString(objDataReader[12]);
                        ListaIngre.Add(Proveedor);
                   }
                }

                return ListaIngre;
             }
             catch (Exception e)
             {
                log.Error("Lista_Proveedores(EXCEPTION): ", e);
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
        public void RegistrarProveedor(ProveedorBean Prov)
        {
            SqlConnection objDB = null;
            int i = Utils.cantidad("Proveedor")+1;
            string ID="PROV00";//8caracteres-4letras-4#
            if (i < 10) Prov.ID = ID + "0" + Convert.ToString(i);
            else Prov.ID = ID + Convert.ToString(i);
			try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "Insert into Proveedor (idIngrediente,razonSocial, estado,contacto,email_contacto,direccion,"+
                                   " ruc, telefono1, cargo_contacto, telefono_contacto, web, observacion, telefono2 values " +
                                    "(@id,@razonsocial,@estado,@contacto,@email_contacto, @direccion, @ruc, @telefono1,@cargo_contacto," +
                                    "@telefono_contacto, @web, @observacion, @telefono2)";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@id", Prov.ID);
                Utils.agregarParametro(objQuery, "@razonsocial", Prov.razonSocial);
                Utils.agregarParametro(objQuery, "@estado", Prov.estado);
                Utils.agregarParametro(objQuery, "@contacto", Prov.contacto);
                Utils.agregarParametro(objQuery, "@email_contacto", Prov.email_contacto);
                Utils.agregarParametro(objQuery, "@direccion", Prov.direccion);
                Utils.agregarParametro(objQuery, "@ruc", Prov.ruc);
                Utils.agregarParametro(objQuery, "@telefono1", Prov.telefono1);
                Utils.agregarParametro(objQuery, "@cargo_contacto", Prov.CargoContacto);
                Utils.agregarParametro(objQuery, "@telefono_contacto", Prov.telefono_contacto);
                Utils.agregarParametro(objQuery, "@web", Prov.web);
                Utils.agregarParametro(objQuery, "@observacion", Prov.Observacion);
                Utils.agregarParametro(objQuery, "@telefono2", Prov.telefono2);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("Registrar_Proveedor(EXCEPTION): ", e);
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
                ProveedorBean Proveedor = null;

                objDB.Open();
                String strQuery = "SELECT * FROM Proveedor WHERE idProveedor = @ID";
                SqlCommand objquery = new SqlCommand(strQuery, objDB);
                BaseDatos.agregarParametro(objquery, "@ID", id);

                SqlDataReader objDataReader = objquery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    objDataReader.Read();
                    Proveedor = new ProveedorBean();

                    Proveedor.ID = Convert.ToString(objDataReader[0]);
                    Proveedor.razonSocial = Convert.ToString(objDataReader[1]);
                    Proveedor.estado = Convert.ToString(objDataReader[2]);
                    Proveedor.contacto = Convert.ToString(objDataReader[3]);
                    Proveedor.email_contacto = Convert.ToString(objDataReader[4]);
                    Proveedor.direccion = Convert.ToString(objDataReader[5]);
                    Proveedor.ruc = Convert.ToString(objDataReader[6]);
                    Proveedor.telefono1 = Convert.ToString(objDataReader[7]);
                    Proveedor.CargoContacto = Convert.ToString(objDataReader[8]);
                    Proveedor.telefono_contacto = Convert.ToString(objDataReader[9]);
                    Proveedor.web = Convert.ToString(objDataReader[10]);
                    Proveedor.Observacion = Convert.ToString(objDataReader[11]);
                    Proveedor.telefono2 = Convert.ToString(objDataReader[12]);
                }
                return Proveedor;
            }
            catch (Exception ex)
            {
                log.Error("Get_Proveedor(EXCEPTION): ", ex);
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
        public void ActualizarProveedor(ProveedorBean Prov)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "UPDATE Proveedor SET razonSocial=@razonsocial, estado=@estado" +
                                  ", contacto=@contacto, email_contacto=@email_contacto,direccion=@direccion,ruc=@ruc,"+
                                  "telefono1=@telefono1, cargo_contacto=@cargo_contacto,telefono_contacto=@telefono_contacto,web=@web,observacion=@observacion,telefono2=@telefono2," +
                                  "WHERE idProveedor = @id";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@id", Prov.ID);
                Utils.agregarParametro(objQuery, "@razonsocial", Prov.razonSocial);
                Utils.agregarParametro(objQuery, "@estado", Prov.estado);
                Utils.agregarParametro(objQuery, "@contacto", Prov.contacto);
                Utils.agregarParametro(objQuery, "@email_contacto", Prov.email_contacto);
                Utils.agregarParametro(objQuery, "@direccion", Prov.direccion);
                Utils.agregarParametro(objQuery, "@ruc", Prov.ruc);
                Utils.agregarParametro(objQuery, "@telefono1", Prov.telefono1);
                Utils.agregarParametro(objQuery, "@cargo_contacto", Prov.CargoContacto);
                Utils.agregarParametro(objQuery, "@telefono_contacto", Prov.telefono_contacto);
                Utils.agregarParametro(objQuery, "@web", Prov.web);
                Utils.agregarParametro(objQuery, "@observacion", Prov.Observacion);
                Utils.agregarParametro(objQuery, "@telefono2", Prov.telefono2);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("Actualizar_Proveedor(EXCEPTION): ", e);
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
            string estado = "INACTIVO";
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "UPDATE Proveedor SET estado=@estado " +
                                  "WHERE idProveedor = @id";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@estado", estado);
                Utils.agregarParametro(objQuery, "@id", ID);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("EliminarProveedor(EXCEPTION): ", e);
            }
            finally
            {
                if (objDB != null)
                {
                    objDB.Close();
                }
            }
        }

        public Boolean existe_ruc(string ruc)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "SELECT * FROM Proveedor WHERE ruc = @ruc";
                SqlCommand objquery = new SqlCommand(strQuery, objDB);
                BaseDatos.agregarParametro(objquery, "@ruc", ruc);

                SqlDataReader objDataReader = objquery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                log.Error("existe_Ruc(EXCEPTION): ", ex);
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
        public Boolean existe_razonSocial(string razonSocial)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "SELECT * FROM Proveedor WHERE  = @ruc";
                SqlCommand objquery = new SqlCommand(strQuery, objDB);
                BaseDatos.agregarParametro(objquery, "@razonsocial", razonSocial);

                SqlDataReader objDataReader = objquery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                log.Error("existe_razonsocial(EXCEPTION): ", ex);
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