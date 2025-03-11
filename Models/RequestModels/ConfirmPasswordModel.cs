namespace MyPetsHealthHubApi.Models.RequestModels
{
    public class ConfirmPasswordModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}