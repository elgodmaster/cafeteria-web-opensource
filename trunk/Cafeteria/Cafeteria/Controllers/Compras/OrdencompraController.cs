using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cafeteria.Models.Compra.Ordencompra;
using Cafeteria.Models.Administracion.Sucursal;
using Cafeteria.Models.Administracion;
using Cafeteria.Models.Compra.Proveedor;
using Cafeteria.Models.Compra;
using Cafeteria.Models.Almacen.Ingrediente;
using Cafeteria.Models.Almacen;

namespace Cafeteria.Controllers.Compras
{
    public class OrdencompraController : Controller
    {
        administracionfacade admin = new administracionfacade();
        comprasfacade comprfacade = new comprasfacade();
        almacenfacade almafacade = new almacenfacade();

        public ActionResult Index()
        {
            List<SucursalBean> suc = admin.listasucursal();
            return View(suc);
        }

        #region Detalle
        public ActionResult Details(int id)
        {
            return View();
        }
        #endregion


        #region crearOrdenCompra
        public ActionResult Registrar()
        {
            OrdencompraBean ordencompra = new OrdencompraBean();
            return View(ordencompra);
        } 


        [HttpPost]
        public ActionResult Registrar(OrdencompraBean orden)
        {
            //int ID = Convert.ToInt32(ordenCompra.idProv);
            orden.idcafeteria = "SUCU0001";
            return RedirectToAction("Registrar2", new { idproveedor = orden.idProv, idsucursal = orden.idcafeteria });
        }

        public ViewResult Registrar2(string idproveedor, string idsucursal) //registrar orden compra.......idproveedor y id sucursal
        {
            OrdenProducto prod = new OrdenProducto();
            ProveedorBean prov = comprfacade.BuscarProveedor(idproveedor);


            int cantidad = 0;
            ProveedorxIngredienteBean productosprov = comprfacade.obtenerlistadeingredientes(idproveedor); // de la tabla productoxpreoveedor
            string idalmacen = comprfacade.obteneralmacen(idsucursal);
            IngredienteXalmacenBean ingredientAlmace = almafacade.obtenerlistadAlmacen(idalmacen); // de la tabla productoxalmacen


            List<Producto> produ = new List<Producto>();

            for (int i = 0; i < ingredientAlmace.listProdalmacen.Count; i++)
            {
                for (int j = 0; j < productosprov.ListadeIngredientesProveedor.Count; j++)
                {
                    if (ingredientAlmace.listProdalmacen[i].ID == productosprov.ListadeIngredientesProveedor[j].ID)
                    {
                        Producto produc = new Producto();
                        produc.idproducto = ingredientAlmace.listProdalmacen[i].ID;
                        produc.Nombre = almafacade.getnombreingrediente(ingredientAlmace.listProdalmacen[i].ID);
                        produc.precio = productosprov.ListadeIngredientesProveedor[j].precio;
                        produc.stockActual = ingredientAlmace.listProdalmacen[i].stockactual;
                        produc.stockMinimo = ingredientAlmace.listProdalmacen[i].stockminimo;
                        produc.stockMaximo = ingredientAlmace.listProdalmacen[i].stockmaximo;
                        if (produc.stockActual <= produc.stockMinimo) { produc.estado = true; cantidad++; }
                        else { produc.estado = false; }
                        produ.Add(produc);
                    }

                }
            }

            prod.listaProducto = produ;
            prod.proveedor = prov.razonSocial;
            prod.idproveedor = idproveedor;//idproveedor
            prod.idcafeteria = idsucursal;
            SucursalBean suc = admin.buscarSucursal(idsucursal);//.getHotel(idhotel);
            prod.nombrecafeteria = suc.nombre;

            //Boolean est = prod.listaProducto[0].estado;
            if (cantidad > 0) prod.estado2 = true; else prod.estado2 = false;
            return View(prod);
        }


        [HttpPost]
        public ActionResult Registrar2(OrdenProducto producto)
        {


            for (int i = 0; i < producto.listaProducto.Count; i++)
            {
                if (producto.listaProducto[i].cantidad > 0)
                {
                    producto.listaProducto[i].estadoguardar = true;

                }
                else
                {
                    producto.listaProducto[i].estadoguardar = false;
                }
            }

            comprfacade.GuardarOrdenCompra(producto);
            return RedirectToAction("Buscar");
        }

        #endregion



        #region Edit
        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion



    }
}
