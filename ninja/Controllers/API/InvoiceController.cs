using ninja.model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ninja.Controllers.API
{
    public class InvoiceController : ApiController
    {

        private readonly InvoiceManager _manager = null;

        public InvoiceController()
        {
            this._manager = new InvoiceManager();
        }

        [HttpDelete]
        public IHttpActionResult DeleteDetail(int id)
        {
            _manager.Delete(id);

            return Ok();
        }
    }
}
