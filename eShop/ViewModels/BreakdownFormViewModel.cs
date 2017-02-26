using eShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eShop.ViewModels
{
    public class BreakdownFormViewModel
    {
        public IEnumerable<PaymentType> PaymentTypes { get; set; }
        public Breakdown Breakdown { get; set; }

        public string Title
        {
            get
            {
                return Breakdown.Id != 0 ? "Edit Breakdown" : "New Breakdown";
            }
        }


        public BreakdownFormViewModel()
        {
            Breakdown = new Breakdown();

            Breakdown.Id = 0;
        }

        public BreakdownFormViewModel(Breakdown breakdown)
        {
            Breakdown = breakdown;
        }
    }
}