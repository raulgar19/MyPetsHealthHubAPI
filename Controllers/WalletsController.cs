using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Services.Interfaces;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly IAppUserService _appUserService;

        public WalletsController(IWalletService walletService, IAppUserService appUserService)
        {
            _walletService = walletService;
            _appUserService = appUserService;
        }

        [HttpGet("walletByUserId/{id}")]
        public async Task<ActionResult<Wallet>> GetWalletByUserId(int id)
        {
            AppUser user = await _appUserService.GetUserById(id);
            
            if (user == null)
            {
                return NotFound();
            }

            Wallet wallet = await _walletService.GetWalletByUserId(user.WalletId.Value);

            return wallet;
        }
    }
}