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
    public class InvoiceDetailViewModel
    {

        public long Id { get; set; }

        [Required]
        //[Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required]
        //[Display(Name = "Cantidad")]
        public double Amount { get; set; }

        [Required]
        //[Display(Name = "Precio Unitario")]
        public double UnitPrice { get; set; }

        [Required]
        public long InvoiceId { get; set; }

        public double TotalPriceWithTaxes { get; set; }
        public double TotalPrice { get; set; }

    }
}
