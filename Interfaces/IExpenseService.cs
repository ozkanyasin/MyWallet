namespace MyWallet
{
    public interface IExpenseService
    {
        Task<Expense> CreateExpense(Expense expense);
        Task<IEnumerable<Expense>> GetAllExpenses();
        Task<Expense> GetExpenseById(int id);
        Task<Expense> GetExpenseByItemName(string itemName);
        Task<Expense> GetExpenseByItemId(int itemId);
        Task<IEnumerable<Expense>> GetExpensesByDate(DateTime dateTime);
        Task DeleteExpense(int id);
        Task<Expense> UpdateExpense(Expense expense);
    }
}