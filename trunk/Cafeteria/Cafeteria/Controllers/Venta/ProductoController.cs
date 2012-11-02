using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models.Compra;
using Cafeteria.Models;
using Cafeteria.Models.Venta.Producto;
using Cafeteria.Models.Almacen.Ingrediente;
using Cafeteria.Models.Venta;
using Cafeteria.Models.Almacen;

namespace Cafeteria.Controllers.Venta
{
    public class ProductoController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(ProductoController));
        ventafacade Ventafacade = new ventafacade();
        almacenfacade Almacenfacade = new almacenfacade();

        #region Producto
        public ActionResult Index()
        {
            return View(Ventafacade.ListarProducto("", ""));
        }


        public ActionResult Details(string id)
        {
            ProductoBean producto = Ventafacade.BuscarProducto(id);
            producto.Nombre_tipo = Ventafacade.get_tipo(producto.ID_Tipo);
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
                Produc = Ventafacade.ListarProducto(Producto.nombre, "");

                if (Produc.Count > 0)
                {
                    ViewBag.error = "El producto ya existe";
                    return View(Producto);
                }
                else
                {

                    Ventafacade.RegistrarProducto(Producto);
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
            List<ProductoBean> prod = Ventafacade.ListarProducto("", "");

   
            ViewBag.estado = 0;
            return View(prod);
        }

        [HttpPost]
        public ActionResult Buscar(string nombre, string ID_tipo)
        {
            ViewBag.estado = 1;
            return View(Ventafacade.ListarProducto(nombre, ID_tipo));
        }

        #endregion

        #region editar
        public ActionResult Edit(string id)
        {
            ProductoBean Producto = Ventafacade.BuscarProducto(id);
            return View(Producto);
        }

        [HttpPost]
        public ActionResult Edit(ProductoBean Produ)
        {
            try
            {
                Ventafacade.ActualizarProducto(Produ);
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
            return View(Ventafacade.BuscarProducto(ID));
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(string ID)
        {
            Ventafacade.EliminarProducto(ID);
            return Json(new { me = "" });
        }

        #endregion
        #endregion

        #region Ingredientes de Producto
        public ViewResult ListarIngredientes(string ID)
        {
            ProductoBean producto = Ventafacade.BuscarProducto(ID);
            ProductoxIngredienteBean prodIngr = new ProductoxIngredienteBean();
            prodIngr = Ventafacade.obtenerlistadeingredientesdeProducto(ID);
            prodIngr.Nombre_Producto = producto.nombre;
            prodIngr.IDProducto = producto.ID;
            prodIngr.tipo = Ventafacade.get_tipo(producto.ID_Tipo);
            if (prodIngr.listaIngre.Count > 0) ViewBag.estado = 0;
            else ViewBag.estado = 1;
            for (int i = 0; i < prodIngr.listaIngre.Count; i++)
            {
                IngredienteBean Ingre = Almacenfacade.buscaringrediente(prodIngr.listaIngre[i].ID);
                prodIngr.listaIngre[i].nombre = Ingre.nombre;

            }
            return View(prodIngr);
            
        }

        public ActionResult ModificarIngredientes(ProductoxIngredienteBean prodxingre)
        {
            Ventafacade.Modificaringredientesdeproducto(prodxingre);
            return RedirectToAction("Index");
        }


        public ActionResult ModificarIngredientes2(ProductoxIngredienteBean prodxingre)
        {
            return View(prodxingre);
        }

        public ActionResult AñadirIngredientes(string ID) //idProducto
        {
            ProductoBean producto = Ventafacade.BuscarProducto(ID);


            List<IngredienteBean> Ingredientes = Almacenfacade.ListarIngrediente("");
            ProductoxIngredienteBean ProdIngre = new ProductoxIngredienteBean();
            ProdIngre.Nombre_Producto = producto.nombre;
            ProdIngre.IDProducto = producto.ID;
            ProdIngre.listaIngre = new List<ProductoxIngrediente>();
            ProductoxIngredienteBean aux = Ventafacade.obtenerlistadeingredientesdeProducto(ID);

            for (int j = 0; j < Ingredientes.Count; j++)
            {
                ProductoxIngrediente product = new ProductoxIngrediente();
                product.ID = Ingredientes[j].ID;
                product.nombre = Ingredientes[j].nombre;
                for (int i = 0; i < aux.listaIngre.Count; i++)
                {
                    if (aux.listaIngre[i].ID == Ingredientes[j].ID) product.estadod_disponible = false;
                }
                ProdIngre.listaIngre.Add(product);
            }

            return View(ProdIngre);
            
        }

        [HttpPost]
        public ActionResult AñadirIngredientes( ProductoxIngredienteBean prodIngre)
        {
            Ventafacade.AñadirIngredientesdeproducto(prodIngre);
            return View();
        }


        #endregion



    }
}
