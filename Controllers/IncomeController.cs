using Microsoft.AspNetCore.Mvc;

namespace MyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class IncomeController : ControllerBase
{
    private readonly IIncomeService _incomeService;
    public IncomeController(IIncomeService _incomeService)
    {
        this._incomeService = _incomeService;
    }

    [HttpPost]
    public async Task<Income> CreateIncome(Income income){
        return await _incomeService.CreateIncome(income);
    }

    [HttpGet]
    public async Task<IEnumerable<IncomeDTO>> GetAllIncomes(){
        return await _incomeService.GetAllIncomes();
    }

    [HttpGet("id")]
    public async Task<Income> GetIncomeById(int id){
        return await _incomeService.GetIncomeById(id);
    }

    [HttpGet("sourceName")]
    public async Task<Income> GetIncomeBySourceName(string sourceName){
        return await _incomeService.GetIncomeBySourceName(sourceName);
    }

    [HttpGet("id")]
    public async Task<Income> GetIncomeBySourceId(int sourceId){
        return await _incomeService.GetIncomeBySourceId(sourceId);
    }

    [HttpGet("dateTime")]
    public async Task<IEnumerable<Income>> GetIncomesByDate(DateTime dateTime){
        return await _incomeService.GetIncomesByDate(dateTime);
    }

    [HttpDelete("id")]
    public async Task DeleteIncomeById(int id){
        await _incomeService.DeleteIncome(id);
    }

    //Todo Update Eklenecek

}
