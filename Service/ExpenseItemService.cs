namespace MyWallet
{
    public class ExpenseItemService : IExpenseItemService
    {

        private readonly IExpenseItemRepository _expenseItemRepository;
        public ExpenseItemService(IExpenseItemRepository _expenseItemRepository)
        {
            this._expenseItemRepository = _expenseItemRepository;
        }

        public async Task<ExpenseItem> CreateExpenseItem(ExpenseItem expenseItem)
        {
            ExpenseItem existingExpenseItem = await _expenseItemRepository.GetExpenseItemByName(expenseItem.Name);
            if (existingExpenseItem != null)
            {
                throw new InvalidDataException("This expense item allready exist");
            }
            return await _expenseItemRepository.CreateExpenseItem(expenseItem);
        }

        public async Task DeleteExpenseItem(int id)
        {
            ExpenseItem item = await _expenseItemRepository.GetExpenseItemById(id);
            if (item == null)
            {
                throw new InvalidOperationException("This expense item doesn't exist");
            }
            await _expenseItemRepository.DeleteExpenseItem(item);
        }

        public async Task<IEnumerable<ExpenseItem?>?> GetAllExpenseItems()
        {
            IEnumerable<ExpenseItem> listOfExpenseItem = await _expenseItemRepository.GetAllExpenseItems();
            if (listOfExpenseItem == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            return listOfExpenseItem;
        }

        public async Task<ExpenseItem> GetExpenseItemById(int id)
        {
            ExpenseItem item = await _expenseItemRepository.GetExpenseItemById(id);
            if (item == null)
            {
                throw new InvalidOperationException("This expense item doesn't exist");
            }
            return item;
        }

        public async Task<ExpenseItem> GetExpenseItemByName(string name)
        {
            ExpenseItem item = await _expenseItemRepository.GetExpenseItemByName(name);
            if (item == null)
            {
                throw new InvalidOperationException("This expense item doesn't exist");
            }
            return item;
        }

        public Task<ExpenseItem> UpdateExpenseItem(ExpenseItem expenseItem)
        {
            throw new NotImplementedException(); //Todo update yapılacak her yerde boşş
        }
    }
}