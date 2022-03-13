namespace MyWallet
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository _expenseRepository)
        {
            this._expenseRepository = _expenseRepository;
        }

        public Task<Expense> CreateExpense(Expense expense)
        {
            throw new NotImplementedException();
        }

        public Task DeleteExpense(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Expense>> GetAllExpenses()
        {
            throw new NotImplementedException();
        }

        public Task<Expense> GetExpenseById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> GetExpenseByItemId(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> GetExpenseByItemName(string itemName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Expense>> GetExpensesByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> UpdateExpense(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}