using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cafeteria.Models.Compra;
using Cafeteria.Models.Compra.Proveedor;
using Cafeteria.Models.Compra.Producto;


namespace Cafeteria.Models.Compra
{
    public class comprasfacade
    {
        IngredienteService Ingredienteservice = new IngredienteService();
        ProveedorService ProveedorService = new ProveedorService();
        ProductoService ProductoService = new ProductoService();

        #region Ingrediente
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

        #region Proveedor

        public List<ProveedorBean> ListarProveedor(string razonsocial, string ruc)
        {
            List<ProveedorBean> prov = new List<ProveedorBean>();
            prov=ProveedorService.ListarProveedor(razonsocial,ruc);

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
        public Boolean existe_ruc(string ruc)
        {
            return(ProveedorService.existe_ruc(ruc));
        }
        public Boolean existe_razonSocial(string razon_social) 
        {
            return (ProveedorService.existe_razonsocial(razon_social));
        }

        #endregion

        #region Producto
        public List<ProductoBean> ListarProducto(string nombre, string idtipo)
        {
            List<ProductoBean> prod = new List<ProductoBean>();
            prod = ProductoService.ListarProducto(nombre, idtipo);

            return prod;
        }
        public void RegistrarProducto(ProductoBean prod)
        {
            ProductoService.RegistrarProducto(prod);
        }
        public ProductoBean BuscarProducto(string id)
        {
            ProductoBean ingre = ProductoService.BuscarProducto(id);
            return ingre;
        }
        public void ActualizarProducto(ProductoBean ingre)
        {
            ProductoService.ActualizarProducto(ingre);
        }
        public void EliminarProducto(string id)
        {
            ProductoService.EliminarProducto(id);
        }
        public string get_tipo(string idtipo)
        {
            return ProductoService.get_tipo(idtipo);
        }
        #endregion

        #region IngredientexProveedor

        public ProveedorxIngredienteBean obtenerlistadeingredientes(string ID)
        {
            return ProveedorService.listardeingredientes(ID);
        }

        public void Modificaringredientes(ProveedorxIngredienteBean prov)
        {
            ProveedorService.ModificarIngredientes(prov);
        }

        public void AñadirIngredientes(ProveedorxIngredienteBean ProvxIngred)
        {
            ProveedorService.AñadirIngredientes(ProvxIngred);
        }

        #endregion


    }
}