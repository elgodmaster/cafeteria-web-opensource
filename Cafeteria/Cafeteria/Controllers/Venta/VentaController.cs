using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cafeteria.Models.Venta.Venta;
using Cafeteria.Models.Venta;
using Cafeteria.Models.Venta.Producto;
using Cafeteria.Models.Administracion;
using Cafeteria.Models.Administracion.Sucursal;

namespace Cafeteria.Controllers.Venta
{
    public class VentaController : Controller
    {
        ventafacade ventfacade = new ventafacade();
        administracionfacade adminfacade = new administracionfacade();

        #region buscarventa
        public ActionResult Buscar()
        {
            VentaBean ventas = new VentaBean();
            List<VentaBean> listadevem = new List<VentaBean>();
            listadevem.Add(ventas);
            @ViewBag.dat = 1;
            return View(listadevem);
        }

        [HttpPost]
        public ActionResult Buscar(string fecha, string idSucursal)
        {
            List<VentaBean> listadevem = new List<VentaBean>();
            @ViewBag.dat = 0;
            listadevem = ventfacade.buscarventas(fecha, idSucursal);


            return View(listadevem);
        }
        #endregion

        #region registrarventa

        public ActionResult Index()
        {
            List<SucursalBean> suc = adminfacade.listasucursal();
            return View(suc);
        }

        public ActionResult Create(string id)
        {
            VentaBean ventas = new VentaBean();
            ventas.idSucursal = id;
            SucursalBean suc=adminfacade.buscarSucursal(ventas.idSucursal);
            ventas.nombresucursal = suc.nombre;

            ventas.listaproductos = ventfacade.obtenerlistaproductos(ventas.idSucursal);  //new List<VentaxProductoBean>();

            List<ProductoBean> listproductos = ventfacade.ListarProducto("", "");// new List<ProductoBean>();
            
            DateTime thisDay = DateTime.Today;
            ventas.fecharegistro = thisDay;
            for (int i = 0; i < ventas.listaproductos.Count; i++)
            {
                for (int j = 0; j < listproductos.Count; j++)
                {
                    if (listproductos[j].id.CompareTo(ventas.listaproductos[i].id)==0)
                    {
                        ventas.listaproductos[i].nombre = listproductos[j].nombre;
                        ventas.listaproductos[i].nombreTipo = listproductos[j].nombreTipo;
                        ventas.listaproductos[i].idTipo = listproductos[j].idTipo;
                    }
                }
            }
            return View(ventas);
        }


        public ActionResult Create2(VentaBean venta)
        {
            try
            {
                return View(venta);
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Registrar(VentaBean venta)
        {
            try
            {
                ventfacade.registrarVenta(venta);
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
