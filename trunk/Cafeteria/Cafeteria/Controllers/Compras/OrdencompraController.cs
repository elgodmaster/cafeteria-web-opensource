using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cafeteria.Controllers.Compras
{
    public class OrdencompraController : Controller
    {
        //
        // GET: /Ordencompra/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Ordencompra/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Ordencompra/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Ordencompra/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Ordencompra/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Ordencompra/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Ordencompra/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Ordencompra/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
