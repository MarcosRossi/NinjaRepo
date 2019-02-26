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
    public class InvoiceDetailController : Controller
    {

        private readonly InvoiceManager _manager = null;

        public InvoiceDetailController()
        {
            this._manager = new InvoiceManager();
        }

        public ActionResult New(int id)
        {
            this.FillDataSourceInvoice(AutoMapper.Mapper.Map<InvoiceViewModel>(_manager.GetById(id)));
            return View("Create", new InvoiceDetailViewModel { InvoiceId = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceDetailViewModel viewModel)
        {
            this.FillDataSourceInvoice(AutoMapper.Mapper.Map<InvoiceViewModel>(_manager.GetById(viewModel.InvoiceId)));
            if (!ModelState.IsValid)
            {
                return View("Create", viewModel);
            }

            _manager.GetById(viewModel.InvoiceId).AddDetail(AutoMapper.Mapper.Map<InvoiceDetail>(viewModel));

            return RedirectToAction("Edit", "Invoice", new { id = viewModel.InvoiceId });
        }

        public ActionResult Edit(int id, int? invoiceId)
        {
            var invoiceDb = _manager.GetById(invoiceId.Value);
            if (invoiceDb == null)
            {
                return View("InvoiceError", new InvoiceErrorViewModel { Message = "The invoice detail that you looking for doesnt exist." });
            }
            this.FillDataSourceInvoice(AutoMapper.Mapper.Map<InvoiceViewModel>(_manager.GetById(invoiceId.Value)));
            return View("Update", AutoMapper.Mapper.Map<InvoiceDetailViewModel>(invoiceDb.GetDetail().FirstOrDefault(d => d.Id == id)));
        }

        [ValidateAntiForgeryToken]
        public ActionResult Update(InvoiceDetailViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", viewModel);
            }

            var invoiceDb = _manager.GetById(viewModel.InvoiceId);
            if (invoiceDb == null)
            {
                return View("InvoiceError", new InvoiceErrorViewModel { Message = "The invoice detail that you looking for doesnt exist." });
            }

            AutoMapper.Mapper.Map(viewModel, invoiceDb.GetDetail().FirstOrDefault(d => d.Id == viewModel.Id));

            return RedirectToAction("Edit", "Invoice", new { id = viewModel.InvoiceId });
        }

        private void FillDataSourceInvoice(InvoiceViewModel invoiceViewModel)
        {
            var results = new List<InvoiceViewModel>();
            results.Add(invoiceViewModel);
            ViewBag.InvoiceList = new SelectList(results, "Id", "ComboName");
        }
    }
}
