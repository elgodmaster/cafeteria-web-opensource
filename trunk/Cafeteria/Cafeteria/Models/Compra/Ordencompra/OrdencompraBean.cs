using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Cafeteria.Models.Compra.Ordencompra
{
    public class Proveedor
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
    }
    
    
    public class OrdencompraBean
    {
         public int idOrdenCompra { get; set; }
        public int idproveedor { get; set; }

        public string nombresucursal { get; set; }

        public int idcafeteria { get; set; }
        
        [Display(Name = "Proveedor")]
        public string idProv { get; set; } 
        
        [Display(Name = "Proveedor")]
        public string nombreproveedor { get; set; }

        [Display(Name = "Ingrediente")]
        public string idIngrediente { get; set; } 
        
        [Display(Name = "Estado")]
        public string estado { get; set; }

        public bool estado2 { get; set; }
        [Display(Name = "Fecha")]
        public string fecha { get; set; }

        [Display(Name = "Precio Total")]
        public decimal preciototal { get; set; }

        //public List<Producto> productoList { get; set; }

        public SelectList proveedorList { get; set; }

        public List<detalleordencompra> detalle { get; set; }
       // List<DetalleOrdenCompra> detalles { get; set; }

        //public List<NotaEntradaBean> notasentrada { get; set; }


        public IEnumerable<Proveedor> getProveedor() 
        {
            List<Proveedor> listaProveedor = new List<Proveedor>();

            String cadenaConfiguracion = WebConfigurationManager.ConnectionStrings["Base"].ConnectionString;

            //String cadenaConfiguracion = ConfigurationManager.ConnectionStrings["CadenaHotelDB"].ConnectionString;

            SqlConnection sqlCon = new SqlConnection(cadenaConfiguracion);
            sqlCon.Open();

            string commandString = "SELECT * FROM Proveedor where estado=1";

            SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            while (dataReader.Read())
            {
                Proveedor proveedor = new Proveedor();
                proveedor.ID = Convert.ToString(dataReader["idProveedor"]);
                proveedor.Nombre = (string)dataReader["razonSocial"];

                listaProveedor.Add(proveedor);
            }

            return listaProveedor;
        }

        

        public OrdencompraBean()
        {
            proveedorList = new SelectList(getProveedor(), "ID", "Nombre");
        }



    }
}