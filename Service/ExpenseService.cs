namespace MyWallet
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository _expenseRepository)
        {
            this._expenseRepository = _expenseRepository;
        }

        public async Task<Expense> CreateExpense(Expense expense)
        {
            Expense existExpense = await _expenseRepository.GetExpenseByName(expense.Name);
            if (existExpense != null)
            {
                throw new InvalidDataException("Please insert different expense name");
            }
            return await _expenseRepository.CreateExpense(expense);
        }

        public async Task DeleteExpense(int id)
        {
            Expense expense = await _expenseRepository.GetExpenseById(id);
            if (expense == null)
            {
                throw new InvalidOperationException("This expense doesn't exist");
            }
            await _expenseRepository.DeleteExpense(expense);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAllExpenses()
        {
            IEnumerable<Expense> expenseList = await _expenseRepository.GetAllExpenses();   //TODO Göz at
            if (expenseList == null)
            {
                throw new InvalidOperationException("List of expenses is empty");
            }
            var total = expenseList.Sum(x => x.Amount);
            List<ExpenseDTO> expenseDTOList = new List<ExpenseDTO>();
            expenseList.Select(x => new ExpenseDTO(){      
                Id = x.Id,
                Amount = x.Amount,
                ExpenseDate = x.ExpenseDate,
                Name = x.Name,
                ExpenseItemName = x.ExpenseItem?.Name
            });

            return expenseDTOList;
        }

        public async Task<Expense> GetExpenseById(int id)
        {
           Expense expense = await _expenseRepository.GetExpenseById(id);
            if(expense == null){
                throw new InvalidOperationException("This expense doesn't exist");
            }
            return expense;
        }

        public async Task<Expense> GetExpenseByItemId(int itemId)
        {
            Expense expense = await _expenseRepository.GetExpenseByItemId(itemId);
            if(expense == null){
                throw new InvalidOperationException("This expense doesn't exist");
            }
            return expense;
        }

        public async Task<Expense> GetExpenseByItemName(string itemName)
        {
            Expense expense = await _expenseRepository.GetExpenseByItemName(itemName);
            if (expense == null)
            {
                throw new InvalidOperationException("This expense doesn't exist");
            }
            return expense;
        }

        public async Task<IEnumerable<Expense>> GetExpensesByDate(DateTime dateTime)
        {
            IEnumerable<Expense> expenseList = await _expenseRepository.GetExpensesByDate(dateTime);
            if (expenseList == null)
            {
                throw new InvalidOperationException("The list of expense for belong this date is empty");
            }
            return expenseList;
        }

        public Task<Expense> UpdateExpense(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}