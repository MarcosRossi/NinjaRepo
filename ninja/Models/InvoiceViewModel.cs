using ninja.model.Entity;
using ninja.Models.CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ninja.Models
{
    public class InvoiceViewModel
    {
        public InvoiceViewModel()
        {
            Details = new List<InvoiceDetailViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Invoice Number")]
        public int? InvoiceNumber { get; set; }

        [Required]
        [ValidTypeInvoice]
        //[Display(Name = "Tipo Factura")]
        public string Type { get; set; }

        public string ComboName { get { return string.Format("FC - {0} {1}", this.Type, this.InvoiceNumber); } }

        public List<InvoiceDetailViewModel> Details { get; set; }
    }
}