namespace MyWallet
{
    public interface IExpenseItemService
    {
        Task<ExpenseItem> CreateExpenseItem(ExpenseItem expenseItem);
        Task<IEnumerable<ExpenseItem?>?> GetAllExpenseItems();
        Task<ExpenseItem> GetExpenseItemByName(string name);
        Task<ExpenseItem> GetExpenseItemById(int id);
        Task DeleteExpenseItem(int id);
        Task<ExpenseItem> UpdateExpenseItem(ExpenseItem expenseItem);
    }
}