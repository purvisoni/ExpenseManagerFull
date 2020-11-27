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

        [HttpPost]
        public IActionResult AddExpense(ExpenseDetailViewModel expense)
        {
            expense.ItemId = Guid.NewGuid();
            if(ModelState.IsValid){
                var expenseToCreate = new ExpenseDetail() {
                    ItemId = expense.ItemId,
                    StoreName = expense.StoreName,
                    ItemName = expense.ItemName,
                    Amount = expense.Amount,
                    ExpenseDate = expense.ExpenseDate,
                    Category = expense.Category
                };
                _theExpenseSystem.AddNewExpense(expenseToCreate);
                return RedirectToAction("ViewExpense");
            }
            else{
                return View("Form", expense);
            }
        }

        public IActionResult ViewExpense()
        {
            List<ExpenseDetail> results = _theExpenseSystem.ViewAllExpense();
            return View(results);
        }

        [HttpPost]
        public IActionResult UpdateExpense(ExpenseDetailViewModel updatedExpense) {
             if (ModelState.IsValid) {
                var expense = new ExpenseDetail() {
                    ItemId = updatedExpense.ItemId,
                    StoreName = updatedExpense.StoreName,
                    ItemName = updatedExpense.ItemName,
                    Amount = updatedExpense.Amount,
                    ExpenseDate = updatedExpense.ExpenseDate,
                    Category = updatedExpense.Category
                };
                _theExpenseSystem.UpdateEachExpense(expense);
                return RedirectToAction("ViewExpense");
            } else {
                ViewBag.IsEditing = true;
                return View("Form", updatedExpense);
            }
        }

        public IActionResult Form()
        {
            ViewBag.IsEditing=false;
            return View();
        }

        public IActionResult Details(Guid id) {
            var expense = _theExpenseSystem.GetExpense(id);
            return View(expense);
        }

        public IActionResult Edit(Guid id) {
            // Get the Expense from the ExpenseSystem
            var expense = _theExpenseSystem.GetExpense(id);

            // build the view model
            var expenseViewModel = new ExpenseDetailViewModel() {
                ItemId = expense.ItemId,
                StoreName = expense.StoreName,
                ItemName = expense.ItemName,
                Amount = expense.Amount,
                ExpenseDate = expense.ExpenseDate,
                Category = expense.Category
            };

            // send the view model
            ViewBag.IsEditing = true;
            return View("Form", expenseViewModel);
        }

        public IActionResult DeleteExpense(Guid id)
        {
            _theExpenseSystem.DeleteEachExpense(id);
            return RedirectToAction("ViewExpense");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
