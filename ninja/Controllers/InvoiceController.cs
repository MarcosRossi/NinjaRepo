using ninja.model.Entity;
using ninja.model.Manager;
using ninja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ninja.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceManager _manager = null;

        public InvoiceController()
        {
            this._manager = new InvoiceManager();
        }
        /// <summary>
        /// Lista todas las facturas en una grilla
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(AutoMapper.Mapper.Map<List<InvoiceViewModel>>(this._manager.GetAll() as List<Invoice>));
        }

        /// <summary>
        ///  Da de alta una factura, a esta opción se accede desde Index
        /// </summary>
        /// <param name="viewmodel"></param>
        /// <returns></returns>
        public ActionResult New()
        {
            return View("Create", new InvoiceViewModel());
        }

        /// <summary>
        /// Lista el detalle de una factura especifica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int id)
        {
            var invoiceDb = _manager.GetById(id);
            if (invoiceDb == null)
            {
                return HttpNotFound("Invoice not exists");
            }
            
            return View(AutoMapper.Mapper.Map<List<InvoiceDetailViewModel>>(invoiceDb.GetDetail() as List<InvoiceDetail>));
        }
        
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", viewmodel);
            }

            _manager.Insert(AutoMapper.Mapper.Map<Invoice>(viewmodel));

            return RedirectToAction("Index", "Invoice");
        }


        public ActionResult Edit(int id)
        {
            var invoiceDb = _manager.GetById(id);
            if (invoiceDb == null)
            {
                return HttpNotFound("Invoice not exists");
            }
            
            return View("Update", AutoMapper.Mapper.Map<InvoiceViewModel>(invoiceDb));
        }

        [ValidateAntiForgeryToken]
        public ActionResult Update(InvoiceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", viewModel);
            }

            var invoiceDb = _manager.GetById(viewModel.Id);
            if (invoiceDb == null)
            {
                return HttpNotFound("Invoice not exists");
            }

            //Assign header ViewModel to Domain.
            AutoMapper.Mapper.Map(viewModel, invoiceDb);
            //Assign details to Domain.
            AutoMapper.Mapper.Map(viewModel.Details.ToList(), invoiceDb.GetDetail() as List<InvoiceDetail>);

            return RedirectToAction("Index", "Invoice");
        }

        public ActionResult Delete(int id)
        {
            _manager.Delete(id);

            return RedirectToAction("Index", "Invoice");
        }
    }
}