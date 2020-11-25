using System;

namespace ExpenseManager
{
    public class ExpenseDetail
    {
        public Guid ItemId { get; set; } = Guid.NewGuid();
        public string StoreName { get; set; }
        public string ItemName { get; set; }
        public double Amount { get; set; }
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public string Category { get; set; }
        //Method
        public override string ToString()
        {
            string details = $"\n----- Item {ItemId} -----\n";
            details += $"Store Name: {StoreName}\n";
            details += $"Item Name: {ItemName}\n";
            details += $"Amount: {Amount}\n";
            details += $"Expense Date: {ExpenseDate}\n";
            details += $"Category: {Category}\n";
            details += "-------------------------\n";
            return details;
        }
        
    }
}