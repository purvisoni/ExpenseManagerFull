using System;
using System.Collections.Generic;


namespace ExpenseManager
{
    public class ExpenseSystem
    {
        public ExpenseSystem(IStoreExpense expenseStorage)
        {
         //dependency injection and init
         _expenseStorage = expenseStorage;
        }

        //storage
        private readonly IStoreExpense _expenseStorage;
       
        public void AddNewExpense(ExpenseDetail newExpense){
            _expenseStorage.AddExpense(newExpense);  
        }

        public List<ExpenseDetail> ViewAllExpense(){
            return _expenseStorage.ViewExpense();
        }

        public void UpdateEachExpense(ExpenseDetail expenseToUpdate) {
            _expenseStorage.UpdateExpense(expenseToUpdate);
        }
            
        public void DeleteEachExpense(Guid id){
            var expense = _expenseStorage.GetById(id);

            if (expense == null) {
                throw new Exception($"Item {id} does not exist!!");
            }
            _expenseStorage.DeleteExpense(expense);
        }

        public ExpenseDetail GetExpense(Guid id) {
            return _expenseStorage.GetById(id);
        }

        public void visitedLocation()
        {
            Console.WriteLine("User visited location..");
        }

    }
}