namespace MyWallet
{
    public class ExpenseRepository : IExpenseRepository{
        private readonly BaseDbContext _baseDbContext;
        public ExpenseRepository(BaseDbContext _baseDbContext)
        {
            this._baseDbContext = _baseDbContext;
        }

        public async Task<Expense> CreateExpense(Expense expense)
        {
            await _baseDbContext.AddAsync(expense);
            await _baseDbContext.SaveChangesAsync();
            return expense;
        }

        public async Task DeleteExpense(Expense expense)
        {
            _baseDbContext.Remove(expense);
            await _baseDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            return await _baseDbContext.Expenses.Include(x => x.ExpenseItem).ToListAsync();
        }

        public async Task<Expense> GetExpenseById(int id)
        {
            return await _baseDbContext.Expenses.FindAsync(id);
        }

        public async Task<Expense> GetExpenseByItemId(int itemId)
        {
            return await _baseDbContext.Expenses.Where(x => x.ExpenseItem.Id == itemId).FirstOrDefaultAsync();
        }

        public async Task<Expense> GetExpenseByItemName(string itemName)
        {
            return await _baseDbContext.Expenses.Where(x => x.ExpenseItem.Name == itemName).FirstOrDefaultAsync();
        }

        public async Task<Expense> GetExpenseByName(string name)
        {
            return await _baseDbContext.Expenses.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByDate(DateTime dateTime)
        {
            return await _baseDbContext.Expenses.Where(x => x.ExpenseDate == dateTime).ToListAsync();
        }

        public async Task<Expense> UpdateExpense(Expense expense)
        {
            _baseDbContext.Update(expense);
            await _baseDbContext.SaveChangesAsync();
            return expense;
        }
    }
}