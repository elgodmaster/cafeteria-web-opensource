using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafeteria.Models.Administracion.Usuario
{
    public class UsuarioxSucursalBean : UsuarioBean
    {
        public DateTime fechainiciotrabajo { get; set; }
        public DateTime fechaingreso { get; set; }
        public DateTime fechafin { get; set; }
        public string sucursal { get; set; }
        public string cargo { get; set; }
        public List<String> dia { get; set; }
        public List<DateTime> horainicio { get; set; }
        public List<DateTime> horafin { get; set; }

        public string perfil { get; set; }

    }

}