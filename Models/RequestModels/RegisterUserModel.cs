namespace MyPetsHealthHubApi.Models.RequestModels
{
    public class RegisterUserModel
    {
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserNick { get; set; }
        public int VetId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}