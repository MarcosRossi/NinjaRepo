using ninja.model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ninja.Controllers.API
{
    public class InvoiceDetailController : ApiController
    {

        private readonly InvoiceManager _manager = null;

        public InvoiceDetailController()
        {
            this._manager = new InvoiceManager();
        }
        
        [HttpDelete]
        public IHttpActionResult DeleteDetail(int id, int? invoiceId)
        {
            var details = _manager.GetById(invoiceId.Value).GetDetail();
            details.Remove(details.FirstOrDefault(det => det.Id == id));

            return Ok();
        }
    }
}
