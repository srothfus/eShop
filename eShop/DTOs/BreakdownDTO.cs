using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using eShop.Models;

namespace eShop.DTOs
{
    public class BreakdownDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Equipment { get; set; }

        public DateTime TimeOfBreakdown { get; set; }

        [Display(Name = "Operator")]
        public string Operator { get; set; }

        [Required]
        [StringLength(255)]
        public string LocationOfBreakdown { get; set; }

        [Required]
        [StringLength(255)]
        public string ProblemDescription { get; set; }

        [StringLength(255)]
        public string ActionDescription { get; set; }
        
        public string WorkDoneBy { get; set; }

        public byte? PaymentTypeId { get; set; }
        
        public bool IsFixed { get; set; }
        public bool IsPaid { get; set; }
        public bool IsResolved { get; set; }

        public BreakdownDTO()
        {
            TimeOfBreakdown = DateTime.Now;
        }
    }
}