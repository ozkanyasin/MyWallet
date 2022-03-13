namespace MyWallet
{
    public class ExpenseItemRepository : IExpenseItemRepository
    {
        private readonly BaseDbContext _baseDbContext;
        public ExpenseItemRepository(BaseDbContext _baseDbContext)
        {
            this._baseDbContext = _baseDbContext;
        }

        public async Task<ExpenseItem> CreateExpenseItem(ExpenseItem expenseItem)
        {
            await _baseDbContext.AddAsync(expenseItem);
            await _baseDbContext.SaveChangesAsync();
            return expenseItem;
        }

        public async Task DeleteExpenseItem(ExpenseItem expenseItem)
        {
             _baseDbContext.ExpenseItems.Remove(expenseItem);
            await _baseDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpenseItem?>?> GetAllExpenseItems()
        {
             return await _baseDbContext.ExpenseItems.ToListAsync();
        }

        public async Task<ExpenseItem> GetExpenseItemById(int id)
        {
            return await _baseDbContext.ExpenseItems.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ExpenseItem> GetExpenseItemByName(string name)
        {
            return await _baseDbContext.ExpenseItems.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<ExpenseItem> UpdateExpenseItem(ExpenseItem expenseItem)
        {
            _baseDbContext.Update(expenseItem);
            await _baseDbContext.SaveChangesAsync();
            return expenseItem;
        }
    }
}