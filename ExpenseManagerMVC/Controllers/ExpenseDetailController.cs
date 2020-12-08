using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExpenseManagerMVC.Models;
using ExpenseManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ExpenseManagerMVC.Controllers
{
    [Authorize]
    public class ExpenseDetailController : Controller
    {
        private ExpenseSystem _theExpenseSystem;
        private UserManager<IdentityUser> _userManager;
        public ExpenseDetailController(ExpenseSystem theExpenseSystem, UserManager<IdentityUser> userManager)
    
        {
            _theExpenseSystem=theExpenseSystem;
            _userManager = userManager;
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
                    Category = expense.Category,
                    UserId = UserId()
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
            List<ExpenseDetail> results = _theExpenseSystem.ViewAllExpense(UserId());
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
                    Category = updatedExpense.Category,
                    UserId = UserId()
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
            var expense = _theExpenseSystem.GetExpense(id, UserId());
            return View(expense);
        }

        public IActionResult Edit(Guid id) {
            // Get the Expense from the ExpenseSystem
            var expense = _theExpenseSystem.GetExpense(id, UserId());

            // build the view model
            var expenseViewModel = new ExpenseDetailViewModel() {
                ItemId = expense.ItemId,
                StoreName = expense.StoreName,
                ItemName = expense.ItemName,
                Amount = expense.Amount,
                ExpenseDate = expense.ExpenseDate,
                Category = expense.Category
                //UserId = UserId()
            };

            // send the view model
            ViewBag.IsEditing = true;
            return View("Form", expenseViewModel);
        }

        public IActionResult DeleteExpense(Guid id)
        {
            _theExpenseSystem.DeleteEachExpense(id, UserId());
            return RedirectToAction("ViewExpense");
        }

        public IActionResult Search() {
            var search = new SearchViewModel() {
                StoreName = "",
                SearchResults = new List<ExpenseDetail>()
            };
            return View(search);
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel search) {
            search.SearchResults = _theExpenseSystem.SearchForExpense(search.StoreName, UserId());
            return View(search);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Guid UserId() {
            string stringUserId = _userManager.GetUserId(User);
            return Guid.Parse(stringUserId);
        }
    }
}
