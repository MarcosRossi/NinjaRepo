using ninja.model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ninja.Controllers
{
    public class InvoiceDetailController : Controller
    {

        // GET: InvoiceDetail/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Details", "Invoice", new { id = id });
        }

        // GET: InvoiceDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceDetail/Create
        [HttpPost]
        public ActionResult Create(InvoiceDetail collection)
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

        // GET: InvoiceDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, InvoiceDetail collection)
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
    }
}
