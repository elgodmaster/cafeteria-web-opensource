using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using log4net;
using System.Data.SqlClient;

namespace Cafeteria.Models.Administracion.Sucursal
{
    public class SucursalDao
    {
        String cadenaDB = WebConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        private static ILog log = LogManager.GetLogger(typeof(BaseDatos));


        public void registrar(SucursalBean suc)
        {
            SqlConnection objDB = null;
            int i = Utils.cantidad("Cafeteria") + 1;
            string ID = "SUCU00";//8caracteres-4letras-4#
            if (i < 10) suc.id = ID + "0" + Convert.ToString(i);
            else suc.id = ID + Convert.ToString(i);
            suc.Razonsocial = "Cafeteria S.A";
            suc.ruc = "45678912591";
            suc.Estado = "ACTIVO";
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "Insert into Cafeteria (idCafeteria,idDistrito,idProvincia,idDepartamento, nombre," +
                                   "razonsocial, ruc, direccion, telefono1, telefono2, estado) values " +
                                    "(@id,@distrito,@provincia,@departamento,@nombre, @razonsocial, @ruc, @direccion,@telefono1," +
                                    "@telefono2, @estado)";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@id", suc.id);
                Utils.agregarParametro(objQuery, "@distrito", suc.idDistrito);
                Utils.agregarParametro(objQuery, "@provincia", suc.idProvincia);
                Utils.agregarParametro(objQuery, "@departamento", suc.idDepartamento);
                Utils.agregarParametro(objQuery, "@nombre", suc.nombre);
                Utils.agregarParametro(objQuery, "@ruc", suc.ruc);
                Utils.agregarParametro(objQuery, "@razonsocial", suc.Razonsocial);
                Utils.agregarParametro(objQuery, "@direccion", suc.direccion);
                Utils.agregarParametro(objQuery, "@telefono1", suc.telefono1);
                Utils.agregarParametro(objQuery, "@telefono2", suc.telefono2);
                Utils.agregarParametro(objQuery, "@estado", suc.Estado);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("Registrar_nuevaSucursal(EXCEPTION): ", e);
            }
            finally
            {
                if (objDB != null)
                {
                    objDB.Close();
                }
            }
        }

        public List<SucursalBean> Listarsucursal()
        {
            //List<SucursalBean> sucur = new List<SucursalBean>();
            //return sucur;

            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                List<SucursalBean> listasucur = new List<SucursalBean>();
                objDB.Open();
                String strQuery = "SELECT * FROM Cafeteria";                                                                     
                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                SqlDataReader objDataReader = objQuery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    while (objDataReader.Read())
                    {
                        SucursalBean sucursal = new SucursalBean();
                        //Proveedor.ID = Convert.ToString(objDataReader["idProveedor"]);
                        //Proveedor.razonSocial = Convert.ToString(objDataReader["razonSocial"]);
                        //Proveedor.estado = Convert.ToString(objDataReader["estado"]);
                        //Proveedor.contacto = Convert.ToString(objDataReader["contacto"]);
                        //Proveedor.email_contacto = Convert.ToString(objDataReader["email_contacto"]);
                        //Proveedor.direccion = Convert.ToString(objDataReader["direccion"]);
                        //P/roveedor.ruc = Convert.ToString(objDataReader["ruc"]);
                        //Proveedor.telefono1 = Convert.ToString(objDataReader["telefono1"]);
                        //Proveedor.CargoContacto = Convert.ToString(objDataReader["cargo_contacto"]);
                        //Proveedor.telefono_contacto = Convert.ToString(objDataReader["telefono_contacto"]);
                        //Proveedor.web = Convert.ToString(objDataReader["web"]);
                        //Proveedor.Observacion = Convert.ToString(objDataReader["observacion"]);
                        //Proveedor.telefono2 = Convert.ToString(objDataReader["telefono2"]);
                        listasucur.Add(sucursal);
                    }
                }

                return listasucur;
            }
            catch (Exception e)
            {
                log.Error("Lista_Sucursal(EXCEPTION): ", e);
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

    }
}