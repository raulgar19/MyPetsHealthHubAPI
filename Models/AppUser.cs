namespace MyPetsHealthHubApi.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public int? SocialUserId { get; set; }
        public SocialUser SocialUser { get; set; }
        public int? VetId { get; set; }
        public Vet Vet { get; set; }
    }
}