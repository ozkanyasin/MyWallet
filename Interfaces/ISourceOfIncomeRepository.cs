namespace MyWallet{
    public interface ISourceOfIncomeRepository{
        Task<SourceOfIncome> CreateSourceOfIncome(SourceOfIncome sourceOfIncome);
        Task<IEnumerable<SourceOfIncome?>?> GetAllSourcesOfIncome();
        Task<SourceOfIncome> GetSourceOfIncomeByName(string name);
        Task<SourceOfIncome> GetSourceOfIncomeById(int id);
        Task DeleteSourceOfIncome(SourceOfIncome sourceOfIncome);
        Task<SourceOfIncome> UpdateSourceOfIncome(SourceOfIncome sourceOfIncome);

    }
}