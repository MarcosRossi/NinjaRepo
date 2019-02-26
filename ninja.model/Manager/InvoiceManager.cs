using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ninja.model.Entity;
using ninja.model.Mock;

namespace ninja.model.Manager
{

    public class InvoiceManager
    {

        private InvoiceMock _mock;

        public InvoiceManager()
        {

            this._mock = InvoiceMock.GetInstance();

        }

        public IList<Invoice> GetAll()
        {

            return this._mock.GetAll();

        }

        public Invoice GetById(long id)
        {

            return this._mock.GetById(id);

        }

        public void Insert(Invoice item)
        {
            this._mock.Insert(item);
        }

        public void Delete(long id)
        {
            Invoice invoice = this.GetById(id);
            //First delete all childen.
            invoice.DeleteDetails();
            //Later delete invoice
            this._mock.Delete(invoice);
        }

        public Boolean Exists(long id)
        {

            return this._mock.Exists(id);

        }
        /// <summary>
        /// Se recibe el Numero de factura y lista de detalles a guardar.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="detail"></param>
        public void CreateDetail(long id, IList<InvoiceDetail> details)
        {
            Invoice invoice = this.GetById(id);
            foreach (var det in details)
            {
                invoice.AddDetail(det);
            }
        }



        public void UpdateDetail(long id, IList<InvoiceDetail> detail)
        {

            /*
              Este método tiene que reemplazar todos los items del detalle de la factura
              por los recibidos por parámetro
             */

            #region Escribir el código dentro de este bloque
            //Clear Details.
            _mock.GetById(id).DeleteDetails();
            //Add new Details.
            _mock.AddDetail(id, detail);
            #endregion Escribir el código dentro de este bloque

        }

    }

}