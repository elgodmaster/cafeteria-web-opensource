﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cafeteria.Models.Compra;
using Cafeteria.Models.Compra.Proveedor;
using Cafeteria.Models.Venta.Producto;
using Cafeteria.Models.Almacen.Ingrediente;
using Cafeteria.Models.Compra.Ordencompra;


namespace Cafeteria.Models.Compra
{
    public class comprasfacade
    {
        //IngredienteService Ingredienteservice = new IngredienteService();
        ProveedorService ProveedorService = new ProveedorService();
        OrdencompraService ordenservice = new OrdencompraService();
        //ProductoService ProductoService = new ProductoService();

        

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


        #region ordencompra


        public string obteneralmacen(string idsucursal)
        {
            string gg = "ALma";
            gg = ordenservice.obteneralmacen(idsucursal);
            return gg;
        }

        public void GuardarOrdenCompra(OrdenProducto ord)
        {
            ordenservice.GuardarOrdenCompra(ord);
        }
        

        #endregion

    }
}