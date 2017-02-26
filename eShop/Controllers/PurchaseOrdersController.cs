using eShop.Models;
using eShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eShop.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        //private ApplicationDbContext _context;

        //public PurchaseOrdersController()
        //{
        //    _context = new ApplicationDbContext();
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);
        //    {
        //        _context.Dispose();
        //    }
        //}

        //// GET: PurchaseOrders
        //public ActionResult Index()
        //{
        //    if (User.IsInRole(RoleName.CanManagePurchaseOrders))
        //        return View("List");

        //    return View("ReadOnlyList");
        //}

        //[Authorize(Roles = RoleName.CanManagePurchaseOrders)]
        //public ViewResult New()
        //{
        //    var customers = _context.Customers.ToList();

        //    var viewModel = new PurchaseOrderFormViewModel
        //    {
        //        Customers = customers
        //    };

        //    return View("PurchaseOrderForm", viewModel);
        //}

        //[Authorize(Roles = RoleName.CanManagePurchaseOrders)]
        //public ActionResult Edit(int id)
        //{
        //    var purchaseOrder = _context.PurchaseOrders.SingleOrDefault(p => p.Id == id);

        //    if (purchaseOrder == null)
        //        return HttpNotFound();

        //    var viewModel = new PurchaseOrderFormViewModel()
        //    {
        //        Customers = _context.Customers.ToList()
        //    };
            
        //    return View("PurchaseOrderForm", viewModel);
        //}
        //public ActionResult Details(int id)
        //{
        //    var purchaseOrder = _context.PurchaseOrders.Include(p => p.Customer).SingleOrDefault(p => p.Id == id);

        //    if (purchaseOrder == null)
        //        return HttpNotFound();

        //    return View(purchaseOrder);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = RoleName.CanManagePurchaseOrders)]
        //public ActionResult Save(PurchaseOrder purchaseOrder)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var viewModel = new PurchaseOrderFormViewModel(purchaseOrder)
        //        {
        //            Customers = _context.Customers.ToList();
        //        };

        //        return View("PurchaseOrderForm", viewModel);
        //    }
        //    return View();
        //}
    }
}