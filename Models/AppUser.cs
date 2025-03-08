namespace MyPetsHealthHubApi.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string Salt { get; set; }
        public int? WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public int? VetId { get; set; }
        public Vet Vet { get; set; }
    }
}