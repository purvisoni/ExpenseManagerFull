using System;

namespace ExpenseManager
{
    public class ExpenseDetailEF
    {
        public Guid ExpenseDetailEFId { get; set; }
        public string StoreName { get; set; }
        public string ItemName { get; set; }
        public double Amount { get; set; }
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public string Category { get; set; }
        //public bool IsDeleted { get; set; }
        public Guid UserId { get; set; }
    }
}