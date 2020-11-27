using System;
using System.Collections.Generic;

namespace ExpenseManager{

    public class ExpenseStorageList : IStoreExpense{

        private readonly List<ExpenseDetail> _expenseList;
        public ExpenseStorageList(){
            _expenseList=new List<ExpenseDetail>();
        }

        public void AddExpense(ExpenseDetail expense){
            _expenseList.Add(expense);
            //Console.WriteLine("Expense has been added sucessfully!!!");
        }

        public List<ExpenseDetail> ViewExpense(){
            return _expenseList;
        }

        public void UpdateExpense(ExpenseDetail expenseToUpdate) {
            ExpenseDetail expense = GetById(expenseToUpdate.ItemId);
            expense.StoreName = expenseToUpdate.StoreName;
            expense.ItemName = expenseToUpdate.ItemName;
            expense.Amount = expenseToUpdate.Amount;
            expense.ExpenseDate = expenseToUpdate.ExpenseDate;
            expense.Category = expenseToUpdate.Category;
        }

     /*   public void UpdateExpense(ExpenseDetail expense){
            expense.ItemId = 
            expense.Amount = amount;
            Console.WriteLine("Updated amount in expense!!!");

        }*/

        public void DeleteExpense(ExpenseDetail expense){
            
            _expenseList.Remove(expense);
            //Console.WriteLine("The expense deleted!!!");

        }

        public ExpenseDetail GetById(Guid id){
            var expense = _expenseList.Find(x => x.ItemId == id);

            if (expense == null) {
                throw new Exception($"Item {id} does not exist in GetById()!!");
            }
            return expense;
        }
    }
}