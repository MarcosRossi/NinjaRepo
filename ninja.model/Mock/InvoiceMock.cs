﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ninja.model.Entity;

namespace ninja.model.Mock
{

    public class InvoiceMock
    {

        #region Singleton

        private static InvoiceMock _instance = null;

        public static InvoiceMock GetInstance()
        {

            if (_instance == null)
                _instance = new InvoiceMock();

            return _instance;

        }

        #endregion Singleton

        /// <summary>
        /// Mock DB
        /// </summary>
        private IList<Invoice> _db;

        private InvoiceMock()
        {

            this._db = new List<Invoice>();

            this.Init();

        }

        private void Init()
        {

            this._db.Add(new Invoice()
            {
                Id = 1000,
                InvoiceNumber = 1000,
                Type = Invoice.Types.A.ToString()
            });

            this._db.Add(new Invoice()
            {
                Id = 1002,
                InvoiceNumber = 1002,
                Type = Invoice.Types.B.ToString()
            });

            Invoice invoice3 = new Invoice()
            {
                Id = 1003,
                InvoiceNumber = 1003,
                Type = Invoice.Types.A.ToString()
            };

            invoice3.AddDetail(new InvoiceDetail() { Id = 1, InvoiceId = 1003, Amount = 22, Description = "Venta varias", UnitPrice = 98.1 });
            this._db.Add(invoice3);

            this._db.Add(new Invoice()
            {
                Id = 1004,
                InvoiceNumber = 1004,
                Type = Invoice.Types.A.ToString()
            });

            //Must be 1005 PK because In Db Exist this PK in other row.
            Invoice invoice5 = new Invoice()
            {
                Id = 1005,
                InvoiceNumber = 1005,
                Type = Invoice.Types.A.ToString()
            };

            //Id Could be 2,3,4 because in invoice3 create row with PK Id=1 and PK for general is idenity (1,1). 
            //InvoiceId FK must be Id invoice5 obnject
            invoice5.AddDetail(new InvoiceDetail() { Id = 1001, InvoiceId = 1005, Amount = 22, Description = "Venta varias", UnitPrice = 98.1 });
            invoice5.AddDetail(new InvoiceDetail() { Id = 1002, InvoiceId = 1005, Description = "Venta insumos varios", Amount = 14, UnitPrice = 4.33 });
            invoice5.AddDetail(new InvoiceDetail() { Id = 1003, InvoiceId = 1005, Description = "Venta insumos tóner", Amount = 5, UnitPrice = 87 });

            this._db.Add(invoice5);

            //Se agrega Invoice with Id =4 for Unit Test Proyect
            this._db.Add(new Invoice()
            {
                Id = 4,
                InvoiceNumber = 1004,
                Type = Invoice.Types.A.ToString()
            });
        }

        public void Delete(Invoice invoice)
        {

            this._db.Remove(invoice);

        }

        public IList<Invoice> GetAll()
        {

            return this._db;

        }

        public Invoice GetById(long id)
        {

            return this._db.Where(x => x.Id == id).FirstOrDefault();

        }

        public void Insert(Invoice item)
        {

            this._db.Add(item);

        }

        public Boolean Exists(long id)
        {

            return this._db.Where(x => x.Id == id).Any();

        }

        public void DeleteDetail(long id)
        {

            this.GetById(id).DeleteDetails();

        }

        public void AddDetail(long id, IList<InvoiceDetail> detail)
        {

            foreach (InvoiceDetail item in detail)
                this.GetById(id).AddDetail(item);

        }

    }

}