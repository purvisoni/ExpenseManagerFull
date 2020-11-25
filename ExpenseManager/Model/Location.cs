using System;

namespace ExpenseManager
{
    public class Location
    {
        public Guid Id { get; set; }
        public string LocationName { get; set; }
        public int NoOfItems { get; set; }
    }
}