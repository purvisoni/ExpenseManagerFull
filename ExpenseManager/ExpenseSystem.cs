using System;
using System.Collections.Generic;


namespace ExpenseManager
{
    public class ExpenseSystem
    {
        public ExpenseSystem(IStoreExpense expenseStorage)
        {//dependency injection and init
         _expenseStorage=expenseStorage;
        
        //adding 2 expense manually
         _expenseStorage.AddExpense(new ExpenseDetail() {
             // ItemId=Guid.NewGuid(),
              StoreName="Superstore",
              ItemName="Milk",
              Amount=4.56,
             // ExpenseDate=DateTime.Now,
              Category="Food"
          });

        _expenseStorage.AddExpense(new ExpenseDetail() {
              //ItemId=Guid.NewGuid(),
              StoreName="Walmart",
              ItemName="Trouser",
              Amount=11,
             // ExpenseDate=DateTime.Now,
              Category="Clothes"
          });
        }

        //storage
        private readonly IStoreExpense _expenseStorage;
       
        public void AddNewExpense(ExpenseDetail newExpense){
            _expenseStorage.AddExpense(newExpense);
            
        }

        public List<ExpenseDetail> ViewAllExpense(){
            return _expenseStorage.ViewExpense();
        }

        public void UpdateEachExpense(Guid id,double amount){
            //Console.WriteLine($"GUID item id is{id}");
            //Console.WriteLine($"Amount is{amount}");
            var expense = _expenseStorage.GetById(id);
            
            if (expense == null) {
                throw new Exception($"Item {id} does not exist!!");
            }
           
            _expenseStorage.UpdateExpense(expense,amount);

        }
        public void DeleteEachExpense(Guid id){
            var expense = _expenseStorage.GetById(id);

            if (expense == null) {
                throw new Exception($"Item {id} does not exist!!");
            }

            _expenseStorage.DeleteExpense(expense);

        }

        public void visitedLocation()
        {
            Console.WriteLine("User visited location..");
        }

    }
}