using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models.Administracion.Login
{
    public class loginBean
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Es necesario que ingrese el Usuario y su Contrasenia")]
        public string Usuario { get; set; }

        [Display(Name = "Contrasenia")]
        [Required(ErrorMessage = "Es necesario que ingrese el Usuario y su Contrasenia")]
        public string Contrasenia { get; set; }
    }
}