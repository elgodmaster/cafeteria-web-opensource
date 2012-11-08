using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Cafeteria.Models.Administracion.Perfil_Usuario;

namespace Cafeteria.Models.Administracion.Usuario
{

    public class Perfiles
    {
        public string ID { get; set; }
        public string nombre { get; set; }
    }

   public class UsuarioViewModelList
    {
        public string ID { get; set; }
        public string user_account { get; set; }
        public string email { get; set; }
        public string idPerfilUsuario { get; set; }
        public string estado { get; set; }
        public string nombrePerfilUsuario { get; set; }
    }

    public class UsuarioViewModelCreate
    {
        public string ID { get; set; }

        [Display(Name = "Perfil Usuario")]
        [Required(ErrorMessage = "Debe ingresar un perfil al usuario")]
        public int idPerfilUsuario { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Debe ingresar un nombre para la cuenta de usuario")]
        [MaxLength(50, ErrorMessage = "El nombre de usuario no debe sobrepasar los 50 caracteres")]
        public string user_account { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [MaxLength(50, ErrorMessage = "La contraseña no debe sobrepasar los 50 caracteres")]
        public string pass { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar su nombre")]
        [MaxLength(50, ErrorMessage = "El nombre no debe sobrepasar los 50 caracteres")]
        public string nombres { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Debe ingresar su apellido paterno")]
        [MaxLength(50, ErrorMessage = "El apellido paterno no debe sobrepasar los 50 caracteres")]
        public string apPat { get; set; }

        [Display(Name = "Apellido Materno")]
        [MaxLength(50, ErrorMessage = "El apellido materno no debe sobrepasar los 50 caracteres")]
        public string apMat { get; set; }

        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(7, ErrorMessage = "Debe ingresar un teléfono de 7 dígitos")]
        [RegularExpression("([0-9]+)", ErrorMessage = "El valor ingresado debe tener la sintaxis de un telefóno")]
        public string celular { get; set; }

        [Display(Name = "Nro. de DNI")]
        [StringLength(12, ErrorMessage = "El nro de documento no debe sobrepasar 8 digitos")]
        public string nroDocumento { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(100, ErrorMessage = "La razón social no debe sobrepasar los 100 caracteres")]
        public string direccion { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Debe elegir un departamento")]
        public string idDepartamento { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Debe elegir un provincia")]
        public string idProvincia { get; set; }

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "Debe elegir un distrito")]
        public string idDistrito { get; set; }

        public List<PerfilUsuarioBean> PerfilesUsuario { get; set; }
        public List<Ubigeo.Ubigeo.Departamento> Departamentos { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }
        
    }

    public class UsuarioBean
    {
        
        public string ID { get; set; }

        [Display(Name = "Perfil Usuario")]
        [Required(ErrorMessage = "Debe ingresar un perfil al usuario")]
        public string idPerfilUsuario { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Debe ingresar un nombre para la cuenta de usuario")]
        [MaxLength(50, ErrorMessage = "El nombre de usuario no debe sobrepasar los 50 caracteres")]
        public string user_account { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [MaxLength(50, ErrorMessage = "La contraseña no debe sobrepasar los 50 caracteres")]
        public string pass { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar su nombre")]
        [MaxLength(50, ErrorMessage = "El nombre no debe sobrepasar los 50 caracteres")]
        public string nombres { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Debe ingresar su apellido paterno")]
        [MaxLength(50, ErrorMessage = "El apellido paterno no debe sobrepasar los 50 caracteres")]
        public string apPat { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "Debe ingresar su apellido materno")]
        [MaxLength(50, ErrorMessage = "El apellido materno no debe sobrepasar los 50 caracteres")]
        public string apMat { get; set; }

        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Debe ingresar 7 dígitos")]
        [RegularExpression("([0-9]+)", ErrorMessage = "El valor ingresado debe tener la sintaxis de un telefóno")]
        public string celular { get; set; }

        [Display(Name = "Nro. de DNI")]
        [StringLength(12, ErrorMessage = "El nro de documento no debe sobrepasar 12 digitos")]
        public string nroDocumento { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "La dirección no debe sobrepasar los 100 caracteres")]
        [Required(ErrorMessage = "Debe ingresar dirección")]
        public string direccion { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Debe elegir un departamento")]
        public string idDepartamento { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Debe elegir una provincia")]
        public string idProvincia { get; set; }

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "Debe elegir un distrito")]
        public string idDistrito { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Display(Name = "Fecha Ingreso")]
        public DateTime fechaIngreso { get; set; }

        [Display(Name = "Fecha Salida")]
        public DateTime fechasalida { get; set; }



        public string nombrePerfilUsuario { get; set; }
        public string nombreDepartamento { get; set; }
        public string nombreProvincia { get; set; }
        public string nombreDistrito { get; set; }

        public List<Ubigeo.Ubigeo.Departamento> Departamentos { get; set; }
        public List<PerfilUsuarioBean> PerfilesUsuario { get; set; }

    }
   
}