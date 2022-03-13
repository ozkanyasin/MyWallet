namespace MyWallet
{
    public interface IIncomeService
    {
        Task<Income> CreateIncome(Income income);
        Task<IEnumerable<IncomeDTO>> GetAllIncomes();
        Task<Income> GetIncomeById(int id);
        Task<Income> GetIncomeBySourceName(string sourceName);
        Task<Income> GetIncomeBySourceId(int sourceId);
        Task<IEnumerable<Income>> GetIncomesByDate(DateTime dateTime);
        Task DeleteIncome(int id);
        Task<Income> UpdateIncome(Income income);
    }
}