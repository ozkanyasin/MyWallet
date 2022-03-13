namespace MyWallet
{
    public interface IExpenseRepository
    {
        Task<Expense> CreateExpense(Expense expense);
        Task<IEnumerable<Expense>> GetAllExpenses();
        Task<Expense> GetExpenseById(int id);
        Task<Expense> GetExpenseByItemName(string itemName);
        Task<Expense> GetExpenseByItemId(int itemId);
        Task<Expense> GetExpenseByName(string name);
        Task<IEnumerable<Expense>> GetExpensesByDate(DateTime dateTime);
        Task DeleteExpense(Expense expense);
        Task<Expense> UpdateExpense(Expense expense);
    }
}