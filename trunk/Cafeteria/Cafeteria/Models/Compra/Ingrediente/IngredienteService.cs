using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafeteria.Models
{
    public class IngredienteService
    {
        Ingredientedao Ingredientedao = new Ingredientedao();
        public List<IngredienteBean> ListarIngrediente(string nombre) 
        {
            List<IngredienteBean> prod = new List<IngredienteBean>();
            Ingredientedao.ListarIngrediente(nombre);

            return prod;
        }

        public void RegistrarIngrediente(IngredienteBean prod)
        {
            Ingredientedao.registraringrediente(prod);
        }
        public IngredienteBean buscaringre(string id)
        {
            return Ingredientedao.BuscarIngre(id);
        }
        public void actualizaringre(IngredienteBean ingre)
        {
            Ingredientedao.ActualizarIngre(ingre);
        }
        public void EliminarIngrediente(string ID)
        {
            Ingredientedao.EliminarIngrediente(ID);
        }

    }
}