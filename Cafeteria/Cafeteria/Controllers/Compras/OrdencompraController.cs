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
using Cafeteria.Models.Almacen.Notaentrada;


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

       


        #region Buscar

        public ActionResult Buscar()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Buscar(string nombre)
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
            orden.idCafeteria = "SUCU0001";
            return RedirectToAction("Registrar2", new { idproveedor = orden.idProveedor, idsucursal = orden.idCafeteria });
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

            for (int i = 0; i < ingredientAlmace.listProdAlmacen.Count; i++)
            {
                for (int j = 0; j < productosprov.listadeIngredientesProveedor.Count; j++)
                {
                    if (ingredientAlmace.listProdAlmacen[i].id == productosprov.listadeIngredientesProveedor[j].id)
                    {
                        Producto produc = new Producto();
                        produc.idproducto = ingredientAlmace.listProdAlmacen[i].id;
                        produc.Nombre = almafacade.getnombreingrediente(ingredientAlmace.listProdAlmacen[i].id);
                        produc.precio = productosprov.listadeIngredientesProveedor[j].precio;
                        produc.stockActual = ingredientAlmace.listProdAlmacen[i].stockactual;
                        produc.stockMinimo = ingredientAlmace.listProdAlmacen[i].stockminimo;
                        produc.stockMaximo = ingredientAlmace.listProdAlmacen[i].stockmaximo;
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
       
        #endregion

        #region Detalle

        
        public ActionResult DetalleOrdenC(int id) //id orden compra
        {
            OrdencompraBean ordencompra = new OrdencompraBean();//comprfacade.buscarOrdenes(id);
            ProveedorBean proveedor = comprfacade.BuscarProveedor(ordencompra.idProveedor);
            ordencompra.nombreProveedor = proveedor.razonSocial;

            for (int i = 0; i < ordencompra.detalle.Count; i++)
            {
                IngredienteBean ingre = almafacade.buscaringrediente(ordencompra.detalle[i].id);
                ordencompra.detalle[i].nombre = ingre.nombre;
            }
            ProveedorxIngredienteBean productos = comprfacade.obtenerlistadeingredientes(ordencompra.idProveedor);
            for (int i = 0; i < ordencompra.detalle.Count; i++)
            {
                for (int j = 0; j < productos.listadeIngredientesProveedor.Count; j++)
                {
                    if (ordencompra.detalle[i].id == productos.listadeIngredientesProveedor[j].id)
                    {
                        ordencompra.detalle[i].preciounitario = productos.listadeIngredientesProveedor[j].precio;
                    }
                }
            }

            List<Notaentradabean> notas = new List<Notaentradabean>();//comprfacade.listarnotasentrada(id);
            for (int i = 0; i < notas.Count; i++)
            {
                int idguiaremision = notas[i].idGuiaRemision;
                List<Notaentrada> not2 = new List<Notaentrada>();//comprfacade.obtenernotas(idguiaremision);
                for (int j = 0; j < not2.Count; j++)
                {
                    for (int k = 0; k < ordencompra.detalle.Count(); k++)
                    {
                        if (ordencompra.detalle[k].id == not2[j].id)
                        {
                            ordencompra.detalle[k].Cantidadentrante += not2[j].cantidadrecibida;
                        }
                    }
                }
            }

            SucursalBean suc = admin.buscarSucursal(ordencompra.idCafeteria);
            ordencompra.nombreSucursal = suc.nombre;
            return View(ordencompra);
        }

        #endregion

        #region Modificar ordencompra
        public ActionResult ModificarOrdenC(int id) //idordencompra
        {
            OrdencompraBean ordencompra = new OrdencompraBean();//comprfacade.buscarOrdenes(id);
            ProveedorBean proveedor = comprfacade.BuscarProveedor(ordencompra.idProveedor);
            ordencompra.nombreProveedor = proveedor.razonSocial;

            for (int i = 0; i < ordencompra.detalle.Count; i++)
            {
                IngredienteBean ingre = almafacade.buscaringrediente(ordencompra.detalle[i].id);
                ordencompra.detalle[i].nombre = ingre.nombre;
            }
            ProveedorxIngredienteBean productos = comprfacade.obtenerlistadeingredientes(ordencompra.idProveedor);
            for (int i = 0; i < ordencompra.detalle.Count; i++)
            {
                for (int j = 0; j < productos.listadeIngredientesProveedor.Count; j++)
                {
                    if (ordencompra.detalle[i].id == productos.listadeIngredientesProveedor[j].id)
                    {
                        ordencompra.detalle[i].preciounitario = productos.listadeIngredientesProveedor[j].precio;
                    }
                }
            }
            SucursalBean suc = admin.buscarSucursal(ordencompra.idCafeteria);
            ordencompra.nombreSucursal = suc.nombre;
            return View(ordencompra);

        }


        public ActionResult GuardarestadoOrdenC(OrdencompraBean orden)
        {
            // guarda el estado de la orden de compra a registrado o cancelado
            //comprfacade.modificarestadoordencompra(orden.idOrdenCompra, orden.estado);
            return RedirectToAction("Buscar");
        }

        #endregion


    }
}
