using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseManager{

    public class ExpenseStorageEF : IStoreExpense{
        private ApplicationContext _context;
        public ExpenseStorageEF(ApplicationContext context){
            _context = context;
        }

        public void AddExpense(ExpenseDetail expense){
            var expenseModel = new ExpenseDetailEF(){
                ExpenseDetailEFId = expense.ItemId,
                StoreName = expense.StoreName,
                ItemName = expense.ItemName,
                Amount = expense.Amount,
                ExpenseDate = expense.ExpenseDate,
                Category = expense.Category
            };
            _context.ExpenseDetails.Add(expenseModel);
            _context.SaveChanges();
        }

        public List<ExpenseDetail> ViewExpense(){
            List<ExpenseDetail> results = new List<ExpenseDetail>();
           // var expenseFromDB = _context.ExpenseDetails.ToList();
          /*  foreach(var expenseFromDB in expensesFromDB)
            {
                var nextExpense = new ExpenseDetail(){
                    ItemId = expenseFromDB.it
                }
            }*/

            return results;
        }

        public void UpdateExpense(ExpenseDetail expenseToUpdate) {
            
        }

     

        public void DeleteExpense(ExpenseDetail expense){
            
            
            //Console.WriteLine("The expense deleted!!!");

        }

        public ExpenseDetail GetById(Guid id){
            
            return null;
        }
    }
}