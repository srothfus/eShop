using eShop.Models;
using eShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eShop.Controllers
{
    [Authorize(Roles = RoleName.CanViewBreakdowns + "," + RoleName.CanManageBreakdowns)]
    public class BreakdownsController : Controller
    {
        private ApplicationDbContext _context;

        public BreakdownsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Breakdowns
        public ActionResult Index()
        {
            var model = _context.Breakdowns.Where(b => b.IsResolved == false).ToList();

            if (User.IsInRole(RoleName.CanManageBreakdowns))
                return View("List", model);
            return View("ReadOnlyList", model);
        }

        [Authorize(Roles = RoleName.CanManageBreakdowns)]
        public ActionResult Search(string searchString, DateTime? startDate, DateTime? endDate, bool showInactive = false)
        {
            var model = _context.Breakdowns.ToList();

            if (!showInactive)
                model = model.Where(b => b.IsResolved == showInactive).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(b => b.Equipment.Contains(searchString)).ToList();
            }

            if (startDate != null)
            {
                model = model.Where(b => b.TimeOfBreakdown >= startDate).ToList();

                if (endDate != null)
                {
                    model = model.Where(b => b.TimeOfBreakdown <= endDate).ToList();
                }
            }

            return View("List", model);
        }

        [Authorize(Roles = RoleName.CanManageBreakdowns)]
        public ViewResult New()
        {
            var paymentTypes = _context.PaymentTypes.ToList();

            var viewModel = new BreakdownFormViewModel
            {
                PaymentTypes = paymentTypes
            };

            return View("BreakdownForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageBreakdowns)]
        public ActionResult Edit(int id)
        {
            var breakdown = _context.Breakdowns.Single(b => b.Id == id);

            if (breakdown == null)
                return HttpNotFound();

            var viewModel = new BreakdownFormViewModel(breakdown)
            {
                PaymentTypes = _context.PaymentTypes.ToList()
            };

            return View("BreakdownForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanViewBreakdowns + "," + RoleName.CanManageBreakdowns)]
        public ActionResult Details(int id)
        {
            var breakdown = _context.Breakdowns.Include(b => b.PaymentType).SingleOrDefault(b => b.Id == id);

            if (breakdown == null)
                return HttpNotFound();

            var viewModel = new BreakdownFormViewModel(breakdown)
            {
                PaymentTypes = _context.PaymentTypes.ToList()
            };

            return View("Details", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageBreakdowns)]
        public ActionResult Save(Breakdown breakdown)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BreakdownFormViewModel(breakdown)
                {
                    PaymentTypes = _context.PaymentTypes.ToList()
                };

                return View("BreakdownForm", viewModel);
            }

            if (breakdown.Id == 0)
            {
                breakdown.TimeOfBreakdown = DateTime.Now;

                _context.Breakdowns.Add(breakdown);
            }
            else
            {
                var breakdownInDb = _context.Breakdowns.Single(b => b.Id == breakdown.Id);

                breakdownInDb.Id = breakdown.Id;
                breakdownInDb.Equipment = breakdown.Equipment;
                breakdownInDb.TimeOfBreakdown = breakdown.TimeOfBreakdown;
                breakdownInDb.Operator = breakdown.Operator;
                breakdownInDb.Location = breakdown.Location;
                breakdownInDb.ProblemDescription = breakdown.ProblemDescription;
                breakdownInDb.ActionDescription = breakdown.ActionDescription;
                breakdownInDb.WorkDoneBy = breakdown.WorkDoneBy;
                breakdownInDb.PaymentTypeId = breakdown.PaymentTypeId;
                breakdownInDb.PaymentType = breakdown.PaymentType;
                breakdownInDb.IsFixed = breakdown.IsFixed;
                breakdownInDb.IsPaid = breakdown.IsPaid;
                breakdownInDb.IsResolved = breakdown.IsResolved;
                breakdownInDb.Comments = breakdown.Comments;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Breakdowns");
        }
    }
}