using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Models.RequestModels;
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

        [HttpGet("getWalletByUserId/{id}")]
        public async Task<ActionResult<Wallet>> GetWalletByUserId(int id)
        {
            Wallet wallet = await _walletService.GetWalletByUserId(id);

            if (wallet == null)
            {
                return NotFound($"Wallet with ID {id} not found.");
            }

            return Ok(wallet);
        }

        [HttpPut("addAmount/{userId}")]
        public async Task<ActionResult<Wallet>> AddAmount(int userId, [FromBody] WalletAmountModel walletAmount)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid wallet ID.");
            }

            if (walletAmount.Amount <= 0)
            {
                return BadRequest("Amount must be greater than zero.");
            }

            Wallet wallet = await _walletService.GetWalletByUserId(userId);
            if (wallet == null)
            {
                return NotFound($"AppUser with ID {userId} not found.");
            }

            wallet.Balance += walletAmount.Amount;

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

        [HttpPut("deductAmount/{userId}")]
        public async Task<ActionResult<Wallet>> DeductAmount(int userId, [FromBody] WalletAmountModel walletAmount)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID.");
            }

            if (walletAmount.Amount <= 0)
            {
                return BadRequest("Amount must be greater than zero.");
            }

            Wallet wallet = await _walletService.GetWalletByUserId(userId);
            if (wallet == null)
            {
                return NotFound($"AppUser with ID {userId} not found.");
            }

            if (wallet.Balance < walletAmount.Amount)
            {
                return BadRequest("Insufficient funds.");
            }

            wallet.Balance -= walletAmount.Amount;

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