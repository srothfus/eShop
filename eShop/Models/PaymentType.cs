using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eShop.Models
{
    public class PaymentType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Payment Type")]
        public string Name { get; set; }
    }
}