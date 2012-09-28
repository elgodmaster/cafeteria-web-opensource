using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;

namespace Cafeteria.Models.Venta.Producto
{
    public class ProductoBean
    {
        public string ID { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar nombre de Producto")]
        [RegularExpression("^[a-zA-Z áéíóúAÉÍÓÚÑñ]+$", ErrorMessage = "El nombre ingresado no es válido")]
        public string nombre { get; set; }
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        public string ID_Tipo { get; set; }
        public string Nombre_tipo { get; set; }
        
        public string estado { get; set; }
        public SelectList Listatipo { get; set; }

        public ProductoBean()
        {
            Listatipo = new SelectList(GetTipo(), "ID", "Nombre");
        }
        public IEnumerable<TipoProducto> GetTipo()
        {
            List<TipoProducto> ListaTipo = new List<TipoProducto>();

            String cadenaConfiguracion = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

            SqlConnection sqlCon = new SqlConnection(cadenaConfiguracion);
            sqlCon.Open();

            string commandString = "SELECT * FROM Tipo ";

            SqlCommand sqlCmd = new SqlCommand(commandString, sqlCon);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            while (dataReader.Read())
            {
                TipoProducto TipoProducto = new TipoProducto();
                TipoProducto.ID = Convert.ToString(dataReader["id"]);
                TipoProducto.nombre = (string)dataReader["nombre"];

                ListaTipo.Add(TipoProducto);
            }

            return ListaTipo;
        }

    }
    public class TipoProducto
    {
        public string ID { get; set; }
        public string nombre { get; set; }
    }
    public class tipo
    {
        public string ID { get; set; }
        public List<TipoProducto> Lista { get; set; }
    }

}