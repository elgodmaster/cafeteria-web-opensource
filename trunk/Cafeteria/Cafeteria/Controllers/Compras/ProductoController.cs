using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models.Compra;
using Cafeteria.Models.Compra.Producto;

namespace Cafeteria.Controllers.Compras
{
    public class ProductoController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(ProductoController));
        comprasfacade comprasfacade = new comprasfacade();

        #region Producto
        public ActionResult Index()
        {
            return View(comprasfacade.ListarProducto("",""));
        }


        public ActionResult Details(string id)
        {
            ProductoBean producto= comprasfacade.BuscarProducto(id);
            producto.Nombre_tipo = comprasfacade.get_tipo(producto.ID_Tipo);
            return View(producto);
        }

        #region Create
        public ActionResult Create()
        {
            ProductoBean producto = new ProductoBean();
            return View(producto);
        }

        [HttpPost]
        public ActionResult Create(ProductoBean Producto)
        {
            try
            {

                Producto.estado = "ACTIVO";
                List<ProductoBean> Produc = new List<ProductoBean>();
                Produc = comprasfacade.ListarProducto(Producto.nombre,"");

                if (Produc.Count > 0)
                {
                    ViewBag.error = "El producto ya existe";
                    return View(Producto);
                }
                else
                {
                    
                    comprasfacade.RegistrarProducto(Producto);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception e)
            {
                log.Error("Create - GET(EXCEPTION):", e);
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }
        #endregion

        #region Buscar
        public ActionResult Buscar()
        {
            List<ProductoBean> prod = comprasfacade.ListarProducto("","");

   
            ViewBag.estado = 0;
            return View(prod);
        }

        [HttpPost]
        public ActionResult Buscar(string nombre, string ID_tipo)
        {
            ViewBag.estado = 1;
            return View(comprasfacade.ListarProducto(nombre, ID_tipo));
        }

        #endregion

        #region editar
        public ActionResult Edit(string id)
        {
            ProductoBean Producto = comprasfacade.BuscarProducto(id);
            return View(Producto);
        }

        [HttpPost]
        public ActionResult Edit(ProductoBean Produ)
        {
            try
            {
                comprasfacade.ActualizarProducto(Produ);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region eliminar
        public ActionResult Delete(string ID)
        {
            return View(comprasfacade.BuscarProducto(ID));
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(string ID)
        {
            comprasfacade.EliminarProducto(ID);
            return Json(new { me = "" });
        }

        #endregion
        #endregion

        #region Ingredientes de Producto
        public ViewResult ListarIngredientes(string ID)
        {
            //ProveedorBean proveedor = comprasfacade.BuscarProveedor(ID);
            //ProveedorxIngredienteBean ProveIngre = new ProveedorxIngredienteBean();
            //ProveIngre = comprasfacade.obtenerlistadeingredientes(ID);
            //ProveIngre.nombre_Proveedor = proveedor.razonSocial;
            //ProveIngre.idproveedor = proveedor.ID;
            //if (ProveIngre.ListadeIngredientesProveedor.Count > 0) ViewBag.estado = 0;
            //else ViewBag.estado = 1;
            //for (int i = 0; i < ProveIngre.ListadeIngredientesProveedor.Count; i++)
            //{
            //    IngredienteBean Ingre = comprasfacade.buscaringrediente(ProveIngre.ListadeIngredientesProveedor[i].ID);
            //    ProveIngre.ListadeIngredientesProveedor[i].nombre = Ingre.nombre;

            //}
            //return View(ProveIngre);
            return View();
        }

        public ActionResult ModificarIngredientes(/*ProveedorxIngredienteBean Prov*/)
        {
            return View(/*Prov*/);
        }

        
        public ActionResult ModificarIngredientes2(/*ProveedorxIngredienteBean Prov*/)
        {
            return View(/*Prov*/);
        }

        public ActionResult AñadirIngredientes(string ID) //idProducto
        {
            //ProveedorBean proveedor = comprasfacade.BuscarProveedor(ID);
            //List<IngredienteBean> Ingredientes = comprasfacade.ListarIngrediente("");
            //ProveedorxIngredienteBean ProveIngre = new ProveedorxIngredienteBean();
            //ProveIngre.nombre_Proveedor = proveedor.razonSocial;
            //ProveIngre.idproveedor = proveedor.ID;
            //ProveIngre.ListadeIngredientesProveedor = new List<ProveedorIngrediente>();
            //ProveedorxIngredienteBean aux = comprasfacade.obtenerlistadeingredientes(ID);
            //for (int j = 0; j < Ingredientes.Count; j++)
            //{
            //    ProveedorIngrediente proveedorIngre = new ProveedorIngrediente();
            //    proveedorIngre.nombre = Ingredientes[j].nombre;
            //    for (int i = 0; i < aux.ListadeIngredientesProveedor.Count; i++)
            //    {
            //        if (aux.ListadeIngredientesProveedor[i].ID == Ingredientes[j].ID) proveedorIngre.Estado_disponible = false;
            //    }
            //    ProveIngre.ListadeIngredientesProveedor.Add(proveedorIngre);
            //}

            //return View(ProveIngre);
            return View();
        }

        [HttpPost]
        public ActionResult AñadirIngredientes(/*ProveedorxIngredienteBean ProvexIngre*/)
        {
            return View();
        }


        #endregion



    }
}
