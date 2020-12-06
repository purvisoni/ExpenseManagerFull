using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager{

    public class ExpenseStorageEF : IStoreExpense{
        private ApplicationContext _context;
        public ExpenseStorageEF(ApplicationContext context){
            _context = context;
        }

        public void AddExpense(ExpenseDetail expense){
            var expenseModel = ConvertToDb(expense);
            _context.ExpenseDetails.Add(expenseModel);
            _context.SaveChanges();
        }

        public List<ExpenseDetail> ViewExpense(){
            List<ExpenseDetail> results = new List<ExpenseDetail>();

            var expensesFromDb = _context.ExpenseDetails
                //.AsNoTracking()
                //.Where(x => x.IsDeleted == false)
                .ToList();

            foreach (var expenseFromDb in expensesFromDb) {
                var nextExpense = ConvertFromDb(expenseFromDb);
                results.Add(nextExpense);
            }
            return results;
        }

        public void UpdateExpense(ExpenseDetail expenseToUpdate) {
            var expenseDb = ConvertToDb(expenseToUpdate);
            _context.ExpenseDetails.Update(expenseDb);
            _context.SaveChanges();
        }

        public void DeleteExpense(ExpenseDetail expense){
            var expenseDb = ConvertToDb(expense);
            _context.ExpenseDetails.Remove(expenseDb);
            _context.SaveChanges();
        }

        public ExpenseDetail GetById(Guid id){
            var expenseFromDb = _context.ExpenseDetails
                .AsNoTracking()
                //.Where(x => x.IsDeleted == false)
                .First(x => x.ExpenseDetailEFId == id);
            var expense = ConvertFromDb(expenseFromDb);
            return expense;
        }

        public static ExpenseDetail ConvertFromDb(ExpenseDetailEF expenseFromDb) {
            return new ExpenseDetail() {
                ItemId = expenseFromDb.ExpenseDetailEFId,
                StoreName = expenseFromDb.StoreName,
                ItemName = expenseFromDb.ItemName,
                Amount = expenseFromDb.Amount,
                ExpenseDate = expenseFromDb.ExpenseDate,
                Category = expenseFromDb.Category
            };
        }

        public static ExpenseDetailEF ConvertToDb(ExpenseDetail expense) {
            return new ExpenseDetailEF() {
                ExpenseDetailEFId = expense.ItemId,
                StoreName = expense.StoreName,
                ItemName = expense.ItemName,
                Amount = expense.Amount,
                ExpenseDate = expense.ExpenseDate,
                Category = expense.Category
            };
        }
    }
}