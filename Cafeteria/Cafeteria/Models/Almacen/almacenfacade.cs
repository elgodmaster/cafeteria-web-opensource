﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cafeteria.Models.almacen.Ingrediente;

namespace Cafeteria.Models.Almacen
{
    public class almacenfacade
    {
        IngredienteService Ingredienteservice = new IngredienteService();

        #region Ingrediente
        public List<IngredienteBean> ListarIngrediente(string nombre)
        {
            List<IngredienteBean> prod = new List<IngredienteBean>();
            prod = Ingredienteservice.ListarIngrediente(nombre);

            return prod;
        }
        public void RegistrarIngrediente(IngredienteBean prod)
        {
            Ingredienteservice.RegistrarIngrediente(prod);
        }
        public IngredienteBean buscaringrediente(string id)
        {
            IngredienteBean ingre = Ingredienteservice.buscaringre(id);
            return ingre;
        }
        public void actualizaringre(IngredienteBean ingre)
        {
            Ingredienteservice.actualizaringre(ingre);
        }
        public void eliminarIngrediente(string id)
        {
            Ingredienteservice.EliminarIngrediente(id);
        }
        #endregion



    }
}