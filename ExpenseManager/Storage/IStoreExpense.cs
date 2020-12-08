using System;
using System.Collections.Generic;

namespace ExpenseManager{
    public interface IStoreExpense{

        void AddExpense(ExpenseDetail expense);

        List<ExpenseDetail> ViewExpense(Guid userId);
        void UpdateExpense(ExpenseDetail expense);
        void DeleteExpense(ExpenseDetail expense, Guid userId);
        ExpenseDetail GetById(Guid id, Guid userId);
    }
}