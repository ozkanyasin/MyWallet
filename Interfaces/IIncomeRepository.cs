namespace MyWallet
{
    public interface IIncomeRepository
    {
        Task<Income> CreateIncome(Income income);
        Task<IEnumerable<Income>> GetAllIncomes();
        Task<Income> GetIncomeById(int id);
        Task<Income> GetIncomeBySourceName(string sourceName);
        Task<Income> GetIncomeBySourceId(int sourceId);
        Task<Income> GetIncomeByName(string name);
        Task<IEnumerable<Income>> GetIncomesByDate(DateTime dateTime);
        Task DeleteIncome(Income income);
        Task<Income> UpdateIncome(Income income);
    }
}