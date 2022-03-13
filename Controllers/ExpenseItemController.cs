using Microsoft.AspNetCore.Mvc;

namespace MyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpenseItemController : ControllerBase
{
    private readonly IExpenseItemService _expenseItemService;
    public ExpenseItemController(IExpenseItemService _expenseItemService)
    {
        this._expenseItemService = _expenseItemService;
    }

    [HttpPost]
    public async Task<ExpenseItem> CreateExpenseItem(ExpenseItem expenseItem){
        return await _expenseItemService.CreateExpenseItem(expenseItem);
    }

    [HttpGet]
    public async Task<IEnumerable<ExpenseItem?>?> GetAllExpenseItems(){
        return await _expenseItemService.GetAllExpenseItems();
    }

    [HttpGet("id")]
    public async Task<ExpenseItem> GetExpenseItemById(int id){
        return await _expenseItemService.GetExpenseItemById(id);
    }

    [HttpGet("name")]
    public async Task<ExpenseItem> GetExpenseItemByName(string name){
        return await _expenseItemService.GetExpenseItemByName(name);
    }

    [HttpDelete("id")]
    public async Task DeleteExpenseItemById(int id)
    {
        await _expenseItemService.DeleteExpenseItem(id);
    }

    //TODO update yapılacak

}
