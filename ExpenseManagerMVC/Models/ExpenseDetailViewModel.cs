using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagerMVC.Models
{
    public class ExpenseDetailViewModel
    {
        public Guid ItemId { get; set; }

        [Required]
        [StringLength(15)]
        public string StoreName { get; set; }

        [Required]
        [StringLength(15)]
        public string ItemName { get; set; }

        [Required]
        public double Amount { get; set; }
        public DateTime ExpenseDate { get; set; }

        [StringLength(50)]
        public string Category { get; set; }
    }
}