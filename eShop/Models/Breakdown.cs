using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eShop.Models
{
    public class Breakdown
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Equipment")]
        public string Equipment { get; set; }

        [Required]
        [Display(Name = "Time")]
        public DateTime TimeOfBreakdown { get; set; }

        [Display(Name = "Operator")]
        public string Operator { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Problem Description")]
        public string ProblemDescription { get; set; }

        [StringLength(255)]
        [Display(Name = "Actions Taken")]
        public string ActionDescription { get; set; }

        [Display(Name = "Work Done By")]
        public string WorkDoneBy { get; set; }

        [Display(Name = "Payment Type")]
        public byte? PaymentTypeId { get; set; }
        
        public PaymentType PaymentType { get; set; }

        [Display(Name = "Payment")]
        public string Payment { get; set; }
        
        [Display(Name = "Fixed?")]
        public bool IsFixed { get; set; }
        [Display(Name = "Paid?")]
        public bool IsPaid { get; set; }
        [Display(Name = "Done?")]
        public bool IsResolved { get; set; }

        [StringLength(255)]
        public string Comments { get; set; }
                
        public Breakdown()
        {
            TimeOfBreakdown = DateTime.Now;

            IsFixed = false;
            IsPaid = false;
            IsResolved = false;
        }
    }
}