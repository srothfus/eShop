using eShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShop.ViewModels
{
    public class PurchaseOrderFormViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}