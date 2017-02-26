using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eShop.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        [Display(Name = "PO#")]
        public string PONumber { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public byte CustomerId { get; set; }

        [StringLength(50)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        [StringLength(10)]
        public string Equipment { get; set; }

        [StringLength(50)]
        [Display(Name = "Driver's Name")]
        public string DriverName { get; set; }

        [Display(Name = "Invoice Available")]
        public bool HasInvoice { get; set; }

        [StringLength(100)]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Display(Name = "Date Issued")]
        public DateTime DateIssued { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(10)]
        public string Cost { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        public PurchaseOrder()
        {
            DateIssued = DateTime.Now;
        }
    }
}