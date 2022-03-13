namespace MyWallet
{
    public class SourceOfIncomeService : ISourceOfIncomeService{

        private readonly ISourceOfIncomeRepository _sourceOfIncomeRepository;
        public SourceOfIncomeService(ISourceOfIncomeRepository _sourceOfIncomeRepository)
        {
            this._sourceOfIncomeRepository = _sourceOfIncomeRepository;
        }

        public async Task<SourceOfIncome> CreateSourceOfIncome(SourceOfIncome IncomingSourceOfIncome)
        {   
            SourceOfIncome existingSource = await _sourceOfIncomeRepository.GetSourceOfIncomeByName(IncomingSourceOfIncome.Name);
            if(existingSource != null){
                throw new InvalidDataException("This source of income allready exist");
            }
            return await _sourceOfIncomeRepository.CreateSourceOfIncome(IncomingSourceOfIncome);
        }

        public async Task DeleteSourceOfIncome(int id)   
        {
            SourceOfIncome source = await _sourceOfIncomeRepository.GetSourceOfIncomeById(id);
            if(source == null){
                throw new InvalidOperationException("This source doesn't exist");
            }
            await _sourceOfIncomeRepository.DeleteSourceOfIncome(source);
        }

        public async Task<IEnumerable<SourceOfIncome?>?> GetAllSourcesOfIncome()
        {
            IEnumerable<SourceOfIncome> listOfSource = await _sourceOfIncomeRepository.GetAllSourcesOfIncome();
            if(listOfSource == null){
                throw new InvalidOperationException("List is empty");
            }
            return listOfSource;
        }

        public async Task<SourceOfIncome> GetSourceOfIncomeById(int id)
        {
            SourceOfIncome source = await _sourceOfIncomeRepository.GetSourceOfIncomeById(id);
            if(source == null){
                throw new InvalidOperationException("This source doesn't exist");
            }
            return source;
        }

        public async Task<SourceOfIncome> GetSourceOfIncomeByName(string name)
        {
            SourceOfIncome source = await _sourceOfIncomeRepository.GetSourceOfIncomeByName(name);
            if(source == null){
                throw new InvalidOperationException("This source doesn't exist");
            }
            return source;
        }

        public Task<SourceOfIncome> UpdateSourceOfIncome(SourceOfIncome sourceOfIncome)
        {
            throw new NotImplementedException();
        }
    }
}