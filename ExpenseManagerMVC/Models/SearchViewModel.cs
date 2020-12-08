using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ExpenseManager;

namespace ExpenseManagerMVC.Models
{
    public class SearchViewModel
    {
        [Required]
        public string StoreName { get; set; }
        public List<ExpenseDetail> SearchResults {get;set;}
    }
}