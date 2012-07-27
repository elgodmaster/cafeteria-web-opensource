using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tesis.Models
{
    public class IngredienteService
    {
        Ingredientedao Ingredientedao = new Ingredientedao();
        public List<IngredienteBean> ListarIngrediente(string nombre) 
        {
            List<IngredienteBean> prod = new List<IngredienteBean>();
            Ingredientedao.listaringrediente(nombre);

            return prod;
        }

        public void RegistrarIngrediente(IngredienteBean prod)
        {
            Ingredientedao.registraringrediente(prod);
        }
        public IngredienteBean buscaringre(int id)
        {
            return Ingredientedao.buscaringre(id);
        }
        public void actualizaringre(IngredienteBean ingre)
        {
            Ingredientedao.actualizaringre(ingre);
        }
    }
}