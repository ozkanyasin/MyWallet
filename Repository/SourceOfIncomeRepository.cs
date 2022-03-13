namespace MyWallet
{
    public class SourceOfIncomeRepository : ISourceOfIncomeRepository
    {
        private readonly BaseDbContext _baseDbContext;
        public SourceOfIncomeRepository(BaseDbContext _baseDbContext)
        {
            this._baseDbContext = _baseDbContext;
        }

        public async Task<SourceOfIncome> CreateSourceOfIncome(SourceOfIncome sourceOfIncome)
        {
            await _baseDbContext.AddAsync(sourceOfIncome);
            await _baseDbContext.SaveChangesAsync();
            return sourceOfIncome;
        }

        public async Task DeleteSourceOfIncome(SourceOfIncome sourceOfIncome)
        {
            _baseDbContext.SourceOfIncomes.Remove(sourceOfIncome);
            await _baseDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SourceOfIncome>> GetAllSourcesOfIncome()
        {
            return await _baseDbContext.SourceOfIncomes.ToListAsync();
        }

        public async Task<SourceOfIncome> GetSourceOfIncomeById(int id)
        {
            return await _baseDbContext.SourceOfIncomes.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<SourceOfIncome> GetSourceOfIncomeByName(string name)
        {
            return await _baseDbContext.SourceOfIncomes.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<SourceOfIncome> UpdateSourceOfIncome(SourceOfIncome sourceOfIncome)
        {
            _baseDbContext.Update(sourceOfIncome);
            await _baseDbContext.SaveChangesAsync();
            return sourceOfIncome;
        }
    }
}