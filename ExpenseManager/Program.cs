using System;
using System.Collections.Generic;

namespace ExpenseManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var expenseStorage = new ExpenseStorageList();
            var theExpenseSystem=new ExpenseSystem(expenseStorage);
            Console.WriteLine("Welcome to Expense Manager Application!");

            while(true)
            {
                Console.WriteLine("Please enter a command:\n"+
                "c-to add expense;\n" +
                "r-to view expense;\n" +
                "u-to update expense;\n" +
                "d-to delete expense;\n" +
                "l-visited location;\n" +
                "q-quit\n ");

                string userInput=Console.ReadLine();
               //Add new expense

                if(userInput=="c")
                {
                    Console.WriteLine("How many items you need to add?");
                    String userInput1=Console.ReadLine();
                    int no=Convert.ToInt32(userInput1);
                    Console.WriteLine("Enter each item details in sequence as 1)Storename 2)Itemname 3)Amount 4)Category:");
                    for(int i=0;i<no;i++){
                      theExpenseSystem.AddNewExpense(new ExpenseDetail()
                     {
                        ItemId=Guid.NewGuid(),
                        StoreName=Console.ReadLine(),
                        ItemName=Console.ReadLine(),
                        Amount=Convert.ToInt32(Console.ReadLine()),
                      //  ExpenseDate=DateTime.Now,
                        Category=Console.ReadLine()
                     });
                    } 
                }
                //View All Expense

                if(userInput=="r")
                {
                  try {
                        List<ExpenseDetail> results = theExpenseSystem.ViewAllExpense();
                        foreach (var expenseDetail in results) {
                            Console.WriteLine(expenseDetail.ToString());
                        } 
                    } catch (Exception e) {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }
                  //Update amount in specific object of expense
                if(userInput=="u")
                {
                  Console.WriteLine("Enter Guid of expense to change:");
                  string userInput1=Console.ReadLine();
                  Guid no=Guid.Parse(userInput1);

                  Console.WriteLine("Enter amount to change:");
                  string userInput2=Console.ReadLine();
                  double amount=Convert.ToDouble(userInput2);
                // theExpenseSystem.UpdateEachExpense(no,amount);
                }

                //Delete specific object of expense
                if(userInput=="d")
                {
                  Console.WriteLine("Enter Guid to delete expense:");
                  string userInput1=Console.ReadLine();
                  Guid no=Guid.Parse(userInput1);
                  theExpenseSystem.DeleteEachExpense(no);
                }

                if(userInput=="l")
                {
                    theExpenseSystem.visitedLocation();
                }

                if(userInput=="q")
                {
                    //to quit
                    break;
                }
            }
        }
    }
}
