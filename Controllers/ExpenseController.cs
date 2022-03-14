using Microsoft.AspNetCore.Mvc;

namespace MyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseService _expenseService;
    public ExpenseController(IExpenseService _expenseService)
    {
        this._expenseService = _expenseService;
    }

    [HttpPost]
    public async Task<Expense> CreateExpense(Expense expense){
        return await _expenseService.CreateExpense(expense);
    }

    [HttpGet]
    public async Task<IEnumerable<ExpenseDTO>> GetAllExpenses(){
        return await _expenseService.GetAllExpenses();
    }

    [HttpGet("id")]
    public async Task<Expense> GetExpenseById(int id){
        return await _expenseService.GetExpenseById(id);
    }

    [HttpGet("expenseItemName")]
    public async Task<Expense> GetExpenseByExpenseItemName(string expenseItemName){
        return await _expenseService.GetExpenseByItemName(expenseItemName);
    }

    [HttpGet("expenseItemId")]
    public async Task<Expense> GetIncomeByExpenseItemId(int expenseItemId){
        return await _expenseService.GetExpenseByItemId(expenseItemId);
    }

    [HttpGet("dateTime")]
    public async Task<IEnumerable<Expense>> GetExpensesByDate(DateTime dateTime){
        return await _expenseService.GetExpensesByDate(dateTime);
    }

    [HttpDelete("id")]
    public async Task DeleteExpenseById(int id){
        await _expenseService.DeleteExpense(id);
    }

    //Todo Update Eklenecek

}
