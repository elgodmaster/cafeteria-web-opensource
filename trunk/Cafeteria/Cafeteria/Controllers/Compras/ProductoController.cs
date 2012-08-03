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



    }
}
