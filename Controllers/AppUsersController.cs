using MyPetsHealthHubApi.Models;
using MyPetsHealthHubApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyPetsHealthHubApi.Models.RequestModels;
using MyPetsHealthHubApi.Helpers;

namespace MyPetsHealthHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IWalletService _walletService;

        public AppUsersController(IAppUserService appUserService, IWalletService walletService)
        {
            _appUserService = appUserService;
            _walletService = walletService;
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserModel registerUser)
        {
            if (registerUser == null)
            {
                return BadRequest(new { message = "El usuario no puede ser nulo" });
            }

            Wallet wallet = new Wallet
            {
                AccountNumber = registerUser.AccountNumber,
                Balance = registerUser.Balance
            };
            await _walletService.CreateWallet(wallet);

            int walletId = wallet.Id;

            AppUser existingUser = await _appUserService.GetUserByEmail(registerUser.Email);
            if (existingUser != null)
            {
                return BadRequest(new { message = "El usuario ya existe" });
            }

            string salt = Encryption.GenerateSalt();
            byte[] encryptedPassword = Encryption.EncryptPassword(registerUser.Password, salt);

            AppUser appUser = new AppUser
            {
                Dni = registerUser.Dni,
                Name = registerUser.Name,
                Surnames = registerUser.Surnames,
                Nickname = registerUser.UserNick,
                Phone = registerUser.Phone,
                Email = registerUser.Email,
                Password = encryptedPassword,
                Salt = salt,
                VetId = registerUser.VetId,
                WalletId = walletId
            };

            await _appUserService.CreateUser(appUser);

            return Ok(new { message = "Usuario registrado correctamente" });
        }

        [HttpPost("userLogin")]
        public async Task<IActionResult> UserLogin([FromBody] LoginModel credentials)
        {

            AppUser appUser = await _appUserService.GetUserByEmail(credentials.Email);

            if (appUser == null)
            {
                return NotFound(new { message = "No se ha encontrado ningún usuario con esos datos" });
            }


            byte[] encryptedInputPassword = Encryption.EncryptPassword(credentials.Password, appUser.Salt);

            if (!Encryption.CompareArrays(appUser.Password, encryptedInputPassword))
            {
                return Unauthorized(new { message = "Las credenciales son erróneas" });
            }

            return Ok(appUser);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
            AppUser appUser = await _appUserService.GetUserById(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return Ok(appUser);
        }

        [HttpGet("getByVetId/{id}")]
        public async Task<ActionResult<List<AppUser>>> GetUserByVetId(int id)
        {
            List<AppUser> appUsers = await _appUserService.GetUsersByVetId(id);
            if (appUsers == null)
            {
                return NotFound();
            }
            return Ok(appUsers);
        }
    }
}