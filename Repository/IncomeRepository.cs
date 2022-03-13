namespace MyWallet
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly BaseDbContext _baseDbContext;
        public IncomeRepository(BaseDbContext _baseDbContext)
        {
            this._baseDbContext = _baseDbContext;
        }

        public async Task<Income> CreateIncome(Income income)
        {
            await _baseDbContext.AddAsync(income);
            await _baseDbContext.SaveChangesAsync();
            return income;
        }

        public async Task DeleteIncome(Income income)
        {
            _baseDbContext.Remove(income);
            await _baseDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Income>> GetAllIncomes()
        {
            return await _baseDbContext.Incomes.Include(x => x.SourceOfIncome).ToListAsync();
        }

        public async Task<IEnumerable<Income>> GetIncomesByDate(DateTime dateTime)
        {
            return await _baseDbContext.Incomes.Where(x => x.IncomeDate == dateTime).ToListAsync();
        }

        public async Task<Income> GetIncomeById(int id)
        {
            return await _baseDbContext.Incomes.FindAsync(id);
        }

        public async Task<Income> GetIncomeByName(string name)
        {
            return await _baseDbContext.Incomes.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Income> GetIncomeBySourceName(string sourceName)
        {
            return await _baseDbContext.Incomes.FirstOrDefaultAsync(x => x.SourceOfIncome.Name == sourceName);
        }

        public async Task<Income> GetIncomeBySourceId(int sourceId)
        {
            return await _baseDbContext.Incomes.FirstOrDefaultAsync(x => x.SourceOfIncome.Id == sourceId);
        }

        public async Task<Income> UpdateIncome(Income income)
        {
            _baseDbContext.Update(income);
            await _baseDbContext.SaveChangesAsync();
            return income;
        }
    }
}