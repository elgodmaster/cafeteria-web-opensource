using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using Cafeteria.Models.Compra;
using Cafeteria.Models;
using Cafeteria.Models.Compra.Proveedor;


namespace Cafeteria.Controllers.Compras
{
    public class ProveedorController : Controller
    {
        private static ILog log = LogManager.GetLogger(typeof(IngredienteController));
        comprasfacade comprasfacade = new comprasfacade();

        #region Proveedor
        public ActionResult Index()
        {
            List<ProveedorBean> prod = comprasfacade.ListarProveedor("", "");
            return View(prod);
            
        }


        public ActionResult Details(string  id)
        {
            ProveedorBean pro = comprasfacade.BuscarProveedor(id);
            return View(pro);
        }

        #region Buscar
        public ActionResult Buscar()
        {
            List<ProveedorBean> prod = comprasfacade.ListarProveedor("", "");


            ViewBag.estado = 0;
            return View(prod);
        }

        [HttpPost]
        public ActionResult Buscar(string nombre, string contacto)
        {
            ViewBag.estado = 1;
            return View(comprasfacade.ListarProveedor(nombre, contacto));
        }

        #endregion

        #region Registrar

        public ActionResult Create()
        {
            return View();
        } 


        [HttpPost]
        public ActionResult Create(ProveedorBean prov)
        {
            try
            {
                Boolean opcion1 = comprasfacade.existe_ruc(prov.ruc);
                Boolean opcion2 = comprasfacade.existe_razonSocial(prov.razonSocial);
                if (opcion1)
                {
                    ViewBag.error1 = "El Proveedor ya existe";
                    return View(prov);
                }
                else
                    if (opcion2)
                    {
                        ViewBag.error2 = "El numero de RUC ya existe";
                        return View(prov);
                    }
                    else
                    {
                        comprasfacade.RegistrarProveedor(prov);
                        return RedirectToAction("Index");
                    }
            }
            catch(Exception e)
            {
                log.Error("Create - GET(EXCEPTION):", e);
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        #endregion

        #region editar
        public ActionResult Edit(string id)
        {
            ProveedorBean Producto = comprasfacade.BuscarProveedor(id);
            return View(Producto);
        }

        [HttpPost]
        public ActionResult Edit(ProveedorBean Proveedor)
        {
            try
            {
                comprasfacade.ActualizarProve(Proveedor);
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
            return View(comprasfacade.BuscarProveedor(ID));
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(string ID)
        {
            comprasfacade.EliminarProveedor(ID);
            return Json(new { me = "" });
        }

        #endregion

        #endregion

        #region ProveedorxIngrediente

        public ViewResult ListarIngredientes(string ID)
        {
            ProveedorBean proveedor = comprasfacade.BuscarProveedor(ID);
            ProveedorxIngredienteBean ProveIngre = new ProveedorxIngredienteBean();
            ProveIngre= comprasfacade.obtenerlistadeingredientes(ID);
            ProveIngre.nombre_Proveedor = proveedor.razonSocial;
            ProveIngre.idproveedor = proveedor.ID;
            if (ProveIngre.ListadeIngredientesProveedor.Count > 0) ViewBag.estado = 0;
            else ViewBag.estado = 1;
            for (int i = 0; i < ProveIngre.ListadeIngredientesProveedor.Count; i++)
            {
                IngredienteBean Ingre= comprasfacade.buscaringrediente(ProveIngre.ListadeIngredientesProveedor[i].ID);
                ProveIngre.ListadeIngredientesProveedor[i].nombre = Ingre.nombre;
                
            }
            return View(ProveIngre);
        }

        public ActionResult ModificarIngredientes(ProveedorxIngredienteBean Prov) 
        {
            return View(Prov);
        }

        
        public ActionResult ModificarIngredientes2(ProveedorxIngredienteBean Prov)
        {
            comprasfacade.Modificaringredientes(Prov);
            return View();
        }

        public ActionResult AñadirIngredientes(string ID) //idproveedor
        {
            ProveedorBean proveedor = comprasfacade.BuscarProveedor(ID);
            List<IngredienteBean> Ingredientes = comprasfacade.ListarIngrediente("");
            ProveedorxIngredienteBean ProveIngre = new ProveedorxIngredienteBean();
            ProveIngre.nombre_Proveedor = proveedor.razonSocial;
            ProveIngre.idproveedor = proveedor.ID;
            ProveIngre.ListadeIngredientesProveedor = new List<ProveedorIngrediente>();
            ProveedorxIngredienteBean aux = comprasfacade.obtenerlistadeingredientes(ID);
            for (int j = 0; j < Ingredientes.Count; j++)
            {
                ProveedorIngrediente proveedorIngre = new ProveedorIngrediente();
                proveedorIngre.nombre = Ingredientes[j].nombre;
                for (int i = 0; i < aux.ListadeIngredientesProveedor.Count; i++)
                {
                    if (aux.ListadeIngredientesProveedor[i].ID == Ingredientes[j].ID) proveedorIngre.Estado_disponible = false;
                }
                ProveIngre.ListadeIngredientesProveedor.Add(proveedorIngre);
            }
            
            return View(ProveIngre);
        }

        [HttpPost]
        public ActionResult AñadirIngredientes(ProveedorxIngredienteBean ProvexIngre)
        {
            comprasfacade.AñadirIngredientes(ProvexIngre);
            return View();
            //RedirectToAction( "ListarIngredientes/ "+ProvexIngre.idproveedor);
        }

        

        #endregion

    }
}
