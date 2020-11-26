using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExpenseManagerMVC.Models;
using ExpenseManager;

namespace ExpenseManagerMVC.Controllers
{
    public class ExpenseDetailController : Controller
    {
        private ExpenseSystem _theExpenseSystem;
        public ExpenseDetailController(ExpenseSystem theExpenseSystem)
        {
            _theExpenseSystem=theExpenseSystem;
        }

        public IActionResult ViewExpense()
        {
            List<ExpenseDetail> results = _theExpenseSystem.ViewAllExpense();
            return View(results);
        }

        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExpense(ExpenseDetail expense)
        {
            _theExpenseSystem.AddNewExpense(expense);
            return RedirectToAction("ViewExpense");
            //return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
