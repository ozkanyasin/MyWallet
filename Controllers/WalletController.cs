using Microsoft.AspNetCore.Mvc;

namespace MyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class WalletController : ControllerBase
{
    private readonly IWalletService _walletService;
    public WalletController(IWalletService _walletService)
    {
        this._walletService = _walletService;
    }

    [HttpPost]
    public async Task<Wallet> CreateWallet(Wallet wallet){
        return await _walletService.CreateWallet(wallet);
    }

    [HttpGet]
    public async Task<IEnumerable<Wallet>> GetAllWallets(){
        return await _walletService.GetAllWallets();
    }

    [HttpGet("id")]
    public async Task<Wallet> GetWalletById(int id){
        return await _walletService.GetWalletById(id);
    }

    [HttpGet("name")]
    public async Task<Wallet> GetWalletByName(string name){
        return await _walletService.GetWalletByName(name);
    }

    [HttpGet("byUserId")]
    public async Task<IEnumerable<Wallet>> GetWalletsByUserId(int id){
        return await _walletService.GetWalletsByUserId(id);
    }

    [HttpDelete("id")]
    public async Task DeleteWallet(int id){
        await _walletService.DeleteWallet(id);
    }

    //Todo Update Eklenecek

}
