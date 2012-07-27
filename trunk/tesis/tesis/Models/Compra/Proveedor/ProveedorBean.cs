using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace tesis.Models.Compra.Proveedor
{
    public class ProveedorBean
    {
        public int ID;
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar nombre de Producto")]
        [RegularExpression("^[a-zA-Z áéíóúAÉÍÓÚÑñ]+$", ErrorMessage = "El nombre ingresado no es válido")]
        public string razonSocial;
        [Display(Name = "Estado")]
        public string estado;
        [Display(Name = "Nombre Contacto")]
        public string contacto;
        [Display(Name = "Email Contacto")]
        public string email_contacto;
        [Display(Name = "Direccion")]
        public string direccion;
        [Display(Name = "Ruc")]
        public string ruc;
        [Display(Name = "Telefono 1")]
        public string telefono1;
        [Display(Name = "Telefono 2")]
        public string telefono2;
        [Display(Name = "Telefono Contacto")]
        public string telefono_contacto;
        [Display(Name = "Descripción")]
        public string descripcion;
        [Display(Name = "Observación")]
        public string observacion;
        [Display(Name = "Web")]
        public string web;


    }
}