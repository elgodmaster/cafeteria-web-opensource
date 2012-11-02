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

                registrarAlmacen(suc.id);


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
                        sucursal.id= Convert.ToString(objDataReader["idCafeteria"]);
                        sucursal.nombre = Convert.ToString(objDataReader["nombre"]);
                        sucursal.Razonsocial = Convert.ToString(objDataReader["razonsocial"]);
                        sucursal.ruc = Convert.ToString(objDataReader["ruc"]);
                        sucursal.direccion = Convert.ToString(objDataReader["direccion"]);
                        sucursal.telefono1 = Convert.ToString(objDataReader["telefono1"]);
                        sucursal.telefono2 = Convert.ToString(objDataReader["telefono2"]);
                        sucursal.Estado = Convert.ToString(objDataReader["estado"]);
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

        private void registrarAlmacen(string IDsucursal)
        {
            SqlConnection objDB = null;
            string IDNUEVO="";
            int i = Utils.cantidad("Cafeteria") + 1;
            string ID = "ALMA00";//8caracteres-4letras-4#
            if (i < 10) IDNUEVO = ID + "0" + Convert.ToString(i);
            else IDNUEVO = ID + Convert.ToString(i);

            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "Insert into Almacen (idCafeteria,idAlmacen) values " +
                                    "(@idCafeteria, @idAlmacen)";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@idCafeteria", IDsucursal);
                Utils.agregarParametro(objQuery, "@idAlmacen", IDNUEVO);
                objQuery.ExecuteNonQuery();



            }
            catch (Exception e)
            {
                log.Error("Registrar_Almacen(EXCEPTION): ", e);
            }
            finally
            {
                if (objDB != null)
                {
                    objDB.Close();
                }
            }

        }

        public SucursalBean buscarSucursal(string Id)
        {

            SucursalBean suc = new SucursalBean();
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                //List<SucursalBean> listasucur = new List<SucursalBean>();
                objDB.Open();
                //String strQuery = "SELECT * FROM Cafeteria Where ";
                String strQuery = "SELECT * FROM Cafeteria WHERE idCafeteria = @ID";
                SqlCommand objquery = new SqlCommand(strQuery, objDB);
                BaseDatos.agregarParametro(objquery, "@ID", Id);
                //SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                SqlDataReader objDataReader = objquery.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    while (objDataReader.Read())
                    {
                        
                        suc.id = Convert.ToString(objDataReader["idCafeteria"]);
                        suc.nombre = Convert.ToString(objDataReader["nombre"]);
                        suc.Razonsocial = Convert.ToString(objDataReader["razonsocial"]);
                        suc.ruc = Convert.ToString(objDataReader["ruc"]);
                        suc.direccion = Convert.ToString(objDataReader["direccion"]);
                        suc.telefono1 = Convert.ToString(objDataReader["telefono1"]);
                        suc.telefono2 = Convert.ToString(objDataReader["telefono2"]);
                        suc.Estado = Convert.ToString(objDataReader["estado"]);
                        //listasucur.Add(sucursal);
                    }
                }

                return suc;
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



            //return suc;
        }

        public void EliminarSucursal(string Id)
        {
            string estado = "INACTIVO";
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "UPDATE Cafeteria SET estado=@estado " +
                                  "WHERE idCafeteria = @id";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@estado", estado);
                Utils.agregarParametro(objQuery, "@id", Id);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("Dar de baja a una Sucursal(EXCEPTION): ", e);
            }
            finally
            {
                if (objDB != null)
                {
                    objDB.Close();
                }
            }
        }

        public void ActualizarSucursal(SucursalBean suc)
        {
            SqlConnection objDB = null;
            try
            {
                objDB = new SqlConnection(cadenaDB);
                objDB.Open();
                String strQuery = "UPDATE Cafeteria SET nombre=@nombre, nombreAdministrador=@nomadmin, estado=@estado " +
                                  " WHERE idCafeteria = @id";

                SqlCommand objQuery = new SqlCommand(strQuery, objDB);
                Utils.agregarParametro(objQuery, "@nombre", suc.nombre);
                Utils.agregarParametro(objQuery, "@nomadmin", suc.nombreadministrador);
                Utils.agregarParametro(objQuery, "@estado", suc.Estado);
                Utils.agregarParametro(objQuery, "@id", suc.id);
                objQuery.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                log.Error("Actualizar_Sucursal(EXCEPTION): ", e);
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