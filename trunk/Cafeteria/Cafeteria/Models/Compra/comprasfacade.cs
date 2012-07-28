using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cafeteria.Models.Compra;
using Cafeteria.Models.Compra.Proveedor;

namespace Cafeteria.Models.Compra
{
    public class comprasfacade
    {
        IngredienteService Ingredienteservice = new IngredienteService();
        ProveedorService ProveedorService = new ProveedorService();
        
        #region ingrediente
        public List<IngredienteBean> ListarIngrediente(string nombre)
        {
            List<IngredienteBean> prod = new List<IngredienteBean>();
            prod=Ingredienteservice.ListarIngrediente(nombre);

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

        #region proveedor

        public List<ProveedorBean> ListarProveedor(string razonsocial, string ruc)
        {
            List<ProveedorBean> prov = new List<ProveedorBean>();
            ProveedorService.ListarProveedor(razonsocial,ruc);

            return prov;
        }
        public void RegistrarProveedor(ProveedorBean proveedor)
        {
            ProveedorService.RegistrarProveedor(proveedor);
        }
        public ProveedorBean BuscarProveedor(string id)
        {
            ProveedorBean prov = ProveedorService.BuscarProveedor(id);
            return prov;
        }
        public void ActualizarProve(ProveedorBean proveedor)
        {
            ProveedorService.ActualizarProveedor(proveedor);
        }
        public void EliminarProveedor(string id)
        {
            ProveedorService.EliminarProveedor(id);
        }
        #endregion
    }
}