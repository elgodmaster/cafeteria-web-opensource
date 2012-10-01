﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models.Almacen.Notaentrada
{
    public class Notaentradabean
    {
        public int idordencompra { get; set; }
        public int idhotel { get; set; }
        public int idproveedor { get; set; }
        public int idguiaRemision { get; set; }

        [Display(Name = "Proveedor")]
        public string nombreproveedor { get; set; }
        [Display(Name = "Cafeteria")]
        public string nombrecafeteria { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Display(Name = "Fecha")]
        public string fechaemitida { get; set; }

        [Display(Name = "Precio Total")]
        public decimal preciototal { get; set; }

        [Display(Name = "Fecha")]
        public string fechaRegistradaOrdenCompra { get; set; }
        public List<Notaentrada> detallenotaentrada { get; set; }

    }
}