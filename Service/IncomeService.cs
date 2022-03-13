namespace MyWallet
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        public IncomeService(IIncomeRepository _incomeRepository)
        {
            this._incomeRepository = _incomeRepository;
        }

        public async Task<Income> CreateIncome(Income IncomingIncome)
        {
            Income existIncome = await _incomeRepository.GetIncomeByName(IncomingIncome.Name);
            if (existIncome != null)
            {
                throw new InvalidDataException("Please insert different income name");
            }
            return await _incomeRepository.CreateIncome(IncomingIncome);
        }

        public async Task DeleteIncome(int id)
        {
            Income income = await _incomeRepository.GetIncomeById(id);
            if (income == null)
            {
                throw new InvalidOperationException("This income doesn't exist");
            }
            await _incomeRepository.DeleteIncome(income);
        }

        public async Task<IEnumerable<IncomeDTO>> GetAllIncomes() // TODO DTO deneme
        {
            IEnumerable<Income> incomeList = await _incomeRepository.GetAllIncomes();
            if (incomeList == null)
            {
                throw new InvalidOperationException("List of income is empty");
            }
            var total = incomeList.Sum(x => x.Amount);
            List<IncomeDTO> incomeDTOList = new List<IncomeDTO>();
            incomeList.Select(x => new IncomeDTO(){      // foreach gibi
                Id = x.Id,
                Amount = x.Amount,
                IncomeDate = x.IncomeDate,
                Name = x.Name,
                SourceOfIncomeName = x.SourceOfIncome?.Name
            });

            return incomeDTOList;
        }

        public async Task<IEnumerable<Income>> GetIncomesByDate(DateTime dateTime)
        {
            IEnumerable<Income> incomeList = await _incomeRepository.GetIncomesByDate(dateTime);
            if(incomeList == null){
                throw new InvalidOperationException("The list of income for belong this date is empty");
            }
            return incomeList;
        }

        public async Task<Income> GetIncomeById(int id)
        {
            Income income = await _incomeRepository.GetIncomeById(id);
            if(income == null){
                throw new InvalidOperationException("This income doesn't exist");
            }
            return income;
        }

        public async Task<Income> GetIncomeBySourceId(int sourceId)
        {
            Income income = await _incomeRepository.GetIncomeBySourceId(sourceId);
            if(income == null){
                throw new InvalidOperationException("This income doesn't exist");
            }
            return income;
        }

        public async Task<Income> GetIncomeBySourceName(string sourceName)
        {
             Income income = await _incomeRepository.GetIncomeBySourceName(sourceName);
            if(income == null){
                throw new InvalidOperationException("This income doesn't exist");
            }
            return income;
        }

        public Task<Income> UpdateIncome(Income income)
        {
            throw new NotImplementedException(); // TODO update
        }
    }
}