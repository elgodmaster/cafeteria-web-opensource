using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using log4net;

namespace Cafeteria.Models.Almacen.Notaentrada
{
    public class NotaentradaDao
    {

        String cadenaDB = WebConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        private static ILog log = LogManager.GetLogger(typeof(BaseDatos));

        public void guardarnotaentrada(Notaentradabean nota, string stado)
        {
            int cantidad2 = 0;

            for (int i = 0; i < nota.detalleNotaEntrada.Count; i++)
            {
                if (nota.detalleNotaEntrada[i].cantidadentrante > 0) cantidad2++;
            }
            /*
              if (cantidad2 > 0)
              {


                  String cadenaConfiguracion = ConfigurationManager.ConnectionStrings["CadenaHotelDB"].ConnectionString;

                  SqlConnection sqlCon = new SqlConnection(cadenaConfiguracion);
                  sqlCon.Open();

                  string commandString = "INSERT INTO Notaentrada (idNotaentrada,fechaEntrega, idOrdencompra) VALUES  (GETDATE(), " + nota.idordencompra + " )";

                  SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);
                  sqlCmd.ExecuteNonQuery();
                  sqlCon.Close();

                  //cambiarestado(nota.idordencompra, estado); // cambia de estado


                  //List<Notaentradabean> ordenes = ListarNotasEntradas(nota.idordencompra);

                  //int cantidad = ordenes.Count;

                  //nota.idGuiaRemision = ordenes[cantidad - 1].idguiaRemision;


                  String cadenaConfiguracion2 = ConfigurationManager.ConnectionStrings["CadenaHotelDB"].ConnectionString;



                  for (int i = 0; i < nota.detallenotaentrada.Count; i++)
                  {
                      if (nota.detallenotaentrada[i].cantidadentrante > 0)
                      {
                          SqlConnection sqlCon2 = new SqlConnection(cadenaConfiguracion2);
                          sqlCon2.Open();

                          string commandString2 = "INSERT INTO GuiaRemisionDetalle (idProducto, idGuiaRemision, cantidadRecibida) VALUES  ( " + nota.detallenotaentrada[i].ID + ","
                                                   + nota.idguiaRemision + "," +
                                                   nota.detallenotaentrada[i].cantidadentrante + " )";

                          SqlCommand sqlCmd2 = new SqlCommand(commandString2, sqlCon2);
                          sqlCmd2.ExecuteNonQuery();
                          sqlCon.Close();
                      }
                  }


              }

              */

        }

        public void actualizarstock(Notaentradabean not)
        {


        }



    }
}