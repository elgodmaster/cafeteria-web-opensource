﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cafeteria.Models.Compra.Producto
{
    public class ProductoService
    {
        ProductoDao ProductoDAo = new ProductoDao();

        public List<ProductoBean> ListarProducto(string nombre)
        {
            List<ProductoBean> prod = new List<ProductoBean>();
            prod = ProductoDAo.ListarProductos(nombre);

            return prod;
        }

        public void RegistrarProducto(ProductoBean prod)
        {
            ProductoDAo.registrarProducto(prod);
        }
        public ProductoBean BuscarProducto(string id)
        {
            return ProductoDAo.BuscarProducto(id);
        }
        public void ActualizarProducto(ProductoBean ingre)
        {
            ProductoDAo.ActualizarProducto(ingre);
        }
        public void EliminarProducto(string ID)
        {
            ProductoDAo.EliminarProducto(ID);
        }

    }
}