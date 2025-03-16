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
        private readonly IPostService _postService;
        private readonly IPetService _petService;
        private readonly IScheduledQueryService _scheduledQueryService;

        public AppUsersController(IAppUserService appUserService, IWalletService walletService, IPostService postService, IPetService petService, IScheduledQueryService scheduledQueryService)
        {
            _appUserService = appUserService;
            _walletService = walletService;
            _postService = postService;
            _petService = petService;
            _scheduledQueryService = scheduledQueryService;
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

        [HttpPost("confirmPassword")]
        public async Task<ActionResult<AppUser>> GetUserByEmail(ConfirmPasswordModel confirmPasswordModel)
        {
            AppUser appUser = await _appUserService.GetUserById(confirmPasswordModel.UserId);
            if (appUser == null)
            {
                return NotFound();
            }

            byte[] encryptedInputPassword = Encryption.EncryptPassword(confirmPasswordModel.Password, appUser.Salt);

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

        [HttpPut("updateUser/{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UpdateUserModel updateUserModel)
        {
            AppUser appUser = await _appUserService.GetUserById(id);
            appUser.Name = updateUserModel.Name;
            appUser.Surnames = updateUserModel.Surnames;
            appUser.Nickname = updateUserModel.Nickname;
            appUser.Email = updateUserModel.Email;

            await _appUserService.UpdateUser(appUser);
            return Ok(new { message = "Usuario actualizado correctamente" });
        }

        [HttpPut("changeBankAccount/{id}")]
        public async Task<ActionResult> ChangeBankAccount(int id, [FromBody] ChangeBankAccountModel changeBankAccountModel)
        {
            AppUser appUser = await _appUserService.GetUserById(id);
            appUser.Wallet.AccountNumber = changeBankAccountModel.BankAccount;

            await _appUserService.UpdateUser(appUser);
            return Ok(new { message = "Número de cuenta actualizado correctamente" });
        }

        [HttpPut("changeEmail/{id}")]
        public async Task<ActionResult> ChangeEmail(int id, [FromBody] ChangeEmailModel changeEmailModel)
        {
            AppUser appUser = await _appUserService.GetUserById(id);
            appUser.Email = changeEmailModel.Email;

            await _appUserService.UpdateUser(appUser);
            return Ok(new { message = "Correo actualizado correctamente" });
        }

        [HttpPut("changePassword/{id}")]
        public async Task<ActionResult> ChangePassword(int id, [FromBody] ChangePasswordModel changePasswordModel)
        {
            AppUser appUser = await _appUserService.GetUserById(id);

            if (appUser == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            try
            {
                byte[] newEncryptedPassword = Encryption.EncryptPassword(changePasswordModel.Password, appUser.Salt);
                appUser.Password = newEncryptedPassword;

                await _appUserService.UpdateUser(appUser);

                return Ok(new { message = "Contraseña actualizada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar la contraseña", error = ex.Message });
            }
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            List<Post> posts = await _postService.GetUserPosts(id);
            if (posts != null || posts.Count > 0)
            {
                await _postService.DeleteUserPosts(posts);
            }

            List<Pet> pets = await _petService.GetPetsByUserId(id);

            List<ScheduledQuery> scheduledQueries = await _scheduledQueryService.GetScheduledQueriesByPetId(pets);
            if (scheduledQueries != null || scheduledQueries.Count > 0)
            {
                await _scheduledQueryService.DeleteScheduledQueries(scheduledQueries);
            }

            if (pets != null | pets.Count > 0)
            {
                await _petService.DeleteUserPets(pets);
            }

            AppUser user = await _appUserService.GetUserById(id);
            await _appUserService.DeleteUser(user);

            Wallet wallet = await _walletService.GetWalletById(user.WalletId);
            await _walletService.DeleteWallet(wallet);

            return Ok("Usuario eliminado correctamente");
        }
    }
}