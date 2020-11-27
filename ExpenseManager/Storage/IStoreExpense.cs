using System;
using System.Collections.Generic;

namespace ExpenseManager{
    public interface IStoreExpense{

        void AddExpense(ExpenseDetail expense);

        List<ExpenseDetail> ViewExpense();
        void UpdateExpense(ExpenseDetail expense);
        void DeleteExpense(ExpenseDetail expense);
        ExpenseDetail GetById(Guid id);
    }
}