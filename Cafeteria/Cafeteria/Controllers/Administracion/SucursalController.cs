﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cafeteria.Models;
using Cafeteria.Models.Administracion.Sucursal;
using log4net;
using Cafeteria.Models.Administracion;
using Cafeteria.Models.Venta.Producto;
using Cafeteria.Models.Venta;

namespace Cafeteria.Controllers.Administracion
{
    public class SucursalController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(SucursalController));
        administracionfacade admin = new administracionfacade();
        ventafacade ventafacede = new ventafacade();

        #region Crear
        public ActionResult Create()
        {
            var sucursal = new SucursalBean();
            try
            {
                sucursal.departamentos = Utils.listarDepartamentos();
                return View(sucursal);
            }
            catch (Exception ex)
            {
                log.Error("Create - GET(EXCEPTION): ", ex);
                ModelState.AddModelError("", ex.Message);
                return View(sucursal);
            }
        }

        [HttpPost]
        public ActionResult Create(SucursalBean suc)
        {
            try
            {
                //registrar a la base 
                admin.registrarSucursal(suc);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        public ActionResult Index()
        {
            List<SucursalBean> suc=admin.listasucursal();
            return View(suc);
        }

        #region editar
        public ActionResult Edit(string id)
        {
            //IngredienteBean ingre = Almacenfacade.buscaringrediente(id);
            
            return View(admin.buscarSucursal(id));
        }

        [HttpPost]
        public ActionResult Edit(SucursalBean suc)
        {
            try
            {
               
                admin.ActualizarSucursal(suc);
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
            return View(admin.buscarSucursal(ID));
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(string ID)
        {
            admin.EliminarSucursal(ID);
            return Json(new { me = "" });
        }

        #endregion


        #region listaproductos

        public ActionResult Listaproductos(string id)//idsucursal
        {

            SucursalBean sucursal = new SucursalBean();
            sucursal = admin.buscarSucursal(id);
            List<sucursalproductoBean> listpro = new List<sucursalproductoBean>();
            listpro = admin.obtenerproductsucursal(id);
            sucursal.listaProductos = listpro;
            if (sucursal.listaProductos.Count > 0) ViewBag.estado = 0;
            else ViewBag.estado = 1;
            for (int i = 0; i < sucursal.listaProductos.Count; i++)
            {
                ProductoBean prod = ventafacede.BuscarProducto(sucursal.listaProductos[i].id);
                sucursal.listaProductos[i].nombre = prod.nombre;

            }
            return View(sucursal);
        }

        public ActionResult añadirproductos(string idSucursal)
        {
            SucursalBean sucursal = new SucursalBean();
            sucursal = admin.buscarSucursal(idSucursal);
            List<ProductoBean> listatootalproductos = ventafacede.ListarProducto("", "");

            List<sucursalproductoBean> listpro = new List<sucursalproductoBean>();
            listpro = admin.obtenerproductsucursal(idSucursal);
            sucursal.listaProductos = new List<sucursalproductoBean>(); ;

            for (int i = 0; i < listatootalproductos.Count; i++)
            {
                sucursalproductoBean aux = new sucursalproductoBean();
                aux.id = listatootalproductos[i].id;
                aux.nombre = listatootalproductos[i].nombre;
                aux.nombreTipo = listatootalproductos[i].nombreTipo;

                for (int j = 0; j < listpro.Count; j++)
                {
                    if (listatootalproductos[i].id == listpro[j].id) aux.estadodispo = true;
                }
                sucursal.listaProductos.Add(aux);

            }

            return View(sucursal);
        }

        [HttpPost]
        public ActionResult añadirproductos(SucursalBean suc)
        {

            for (int i = 0; i < suc.listaProductos.Count; i++)
            {
                String aux = suc.listaProductos[i].precioventa2;
                if (!string.IsNullOrEmpty(aux))
                {
                    suc.listaProductos[i].precioventa = Convert.ToDecimal(aux, new System.Globalization.CultureInfo("en-US"));
                }
            }
            
            admin.añadirproductos(suc);
            return RedirectToAction("Listaproductos/" + suc.id, "Sucursal");
        }

        public ActionResult modificarproduc(SucursalBean suc)
        { 
            return View(suc);
        }

        public ActionResult modificarproduc2(SucursalBean suc)
        {
            for (int i = 0; i < suc.listaProductos.Count; i++)
            {
                String aux = suc.listaProductos[i].precioventa2;
                if (buscar(aux))
                {
                    suc.listaProductos[i].precioventa = Convert.ToDecimal(aux, new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    suc.listaProductos[i].precioventa = Convert.ToDecimal(aux);
                }

            } 
            admin.modificarproductos(suc);
            return RedirectToAction("Listaproductos/" + suc.id, "Sucursal");
        }

        private bool buscar(string aux)
        {
            string valor =".";
            char valor2 = valor[0];
            for (int i = 0; i < aux.Length; i++)
            {
                if (aux[i]==valor2) return true;

            }
            return false;
        }
        #endregion

    }
}
