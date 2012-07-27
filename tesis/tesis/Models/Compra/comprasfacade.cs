using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cafeteria.Models.Compra;

namespace Cafeteria.Models.Compra
{
    public class comprasfacade
    {
        IngredienteService Ingredienteservice = new IngredienteService();
        public List<IngredienteBean> ListarIngrediente(string nombre)
        {
            List<IngredienteBean> prod = new List<IngredienteBean>();
            Ingredienteservice.ListarIngrediente(nombre);

            return prod;
        }
        public void RegistrarIngrediente(IngredienteBean prod)
        {
            Ingredienteservice.RegistrarIngrediente(prod);
        }
        public IngredienteBean buscaringrediente(int id)
        {
            IngredienteBean ingre = Ingredienteservice.buscaringre(id);
            return ingre;
        }
        public void actualizaringre(IngredienteBean ingre)
        {
            Ingredienteservice.actualizaringre(ingre);
        }
        public void eliminarIngrediente(int id)
        {

        }

    }
}