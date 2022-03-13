namespace MyWallet{
    public interface ISourceOfIncomeService{
        Task<SourceOfIncome> CreateSourceOfIncome(SourceOfIncome sourceOfIncome);
        Task<IEnumerable<SourceOfIncome?>?> GetAllSourcesOfIncome();
        Task<SourceOfIncome> GetSourceOfIncomeByName(string name);
        Task<SourceOfIncome> GetSourceOfIncomeById(int id);
        Task DeleteSourceOfIncome(int id);
        Task<SourceOfIncome> UpdateSourceOfIncome(SourceOfIncome sourceOfIncome);
    }
}