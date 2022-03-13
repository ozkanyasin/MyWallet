using Microsoft.AspNetCore.Mvc;

namespace MyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class SourceOfIncomeController : ControllerBase
{
    private readonly ISourceOfIncomeService _sourceOfIncomeService;
    public SourceOfIncomeController(ISourceOfIncomeService _sourceOfIncomeService)
    {
        this._sourceOfIncomeService = _sourceOfIncomeService;
    }

    [HttpPost]
    public async Task<SourceOfIncome> CreateSourceOfIncome(SourceOfIncome sourceOfIncome){
        return await _sourceOfIncomeService.CreateSourceOfIncome(sourceOfIncome);
    }

    [HttpGet]
    public async Task<IEnumerable<SourceOfIncome?>?> GetAllSourcesOfIncome(){
        return await _sourceOfIncomeService.GetAllSourcesOfIncome();
    }

    [HttpGet("id")]
    public async Task<SourceOfIncome> GetSourceOfIncomeById(int id){
        return await _sourceOfIncomeService.GetSourceOfIncomeById(id);
    }

    [HttpGet("name")]
    public async Task<SourceOfIncome> GetSourceOfIncomeByName(string name){
        return await _sourceOfIncomeService.GetSourceOfIncomeByName(name);
    }

    [HttpDelete("id")]
    public async Task DeleteSourceOfIncomeById(int id)
    {
        await _sourceOfIncomeService.DeleteSourceOfIncome(id);
    }

    //TODO update yapılacak

}
