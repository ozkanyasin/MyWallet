namespace MyWallet
{
    public interface IExpenseItemRepository
    {
        Task<ExpenseItem> CreateExpenseItem(ExpenseItem expenseItem);
        Task<IEnumerable<ExpenseItem?>?> GetAllExpenseItems();
        Task<ExpenseItem> GetExpenseItemByName(string name);
        Task<ExpenseItem> GetExpenseItemById(int id);
        Task DeleteExpenseItem(ExpenseItem expenseItem);
        Task<ExpenseItem> UpdateExpenseItem(ExpenseItem expenseItem);
    }
}