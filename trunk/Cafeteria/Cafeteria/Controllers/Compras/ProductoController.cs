using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models.Compra;
using cafeteria.Models.Compra.Producto;

namespace cafeteria.Controllers.Compras
{
    public class ProductoController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(ProductoController));
        comprasfacade comprasfacade = new comprasfacade();

        public ActionResult Index()
        {
            return View(comprasfacade.ListarProducto(""));
        }


        public ActionResult Details(string id)
        {
            ProductoBean producto= comprasfacade.BuscarProducto(id);

            return View();
        }

        #region Create
        public ActionResult Create()
        {
            ProductoBean producto = new ProductoBean();
            return View(producto);
        }

        [HttpPost]
        public ActionResult Create(ProductoBean Producto)//ProductoBean producto)
        {
            try
            {
                //ProductoBean Producto = new ProductoBean();
                //Producto.nombre = nombre;
                //Producto.descripcion = descripcion;
                Producto.estado = "ACTIVO";
                List<ProductoBean> Produc = new List<ProductoBean>();
                Produc = comprasfacade.ListarProducto(Producto.nombre);

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
        #region buscar
        public ActionResult Buscar()
        {
            List<ProductoBean> prod = new List<ProductoBean>();
            ViewBag.estado = 0;
            return View(prod);
        }

        [HttpPost]
        public ActionResult Buscar(string nombre)
        {
            ViewBag.estado = 1;
            return View(comprasfacade.ListarProducto(nombre));
        }

        #endregion
        #region editar
        public ActionResult Edit(string id)
        {
            ProductoBean ingre = comprasfacade.BuscarProducto(id);
            return View(ingre);
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

    }
}
