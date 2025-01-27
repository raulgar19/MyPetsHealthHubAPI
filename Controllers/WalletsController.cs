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

            Wallet wallet = await _walletService.GetWalletById(user.WalletId.Value);

            return wallet;
        }

        [HttpPut("addAmount/{id}")]
        public async Task<ActionResult<Wallet>> AddAmount(int id, [FromBody] decimal amount)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid wallet ID.");
            }

            if (amount <= 0)
            {
                return BadRequest("Amount must be greater than zero.");
            }

            var wallet = await _walletService.GetWalletById(id);
            if (wallet == null)
            {
                return NotFound($"Wallet with ID {id} not found.");
            }

            wallet.Balance += amount;

            try
            {
                await _walletService.UpdateWallet(wallet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the wallet: {ex.Message}");
            }

            return Ok(wallet);
        }

    }
}