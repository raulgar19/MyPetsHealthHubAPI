namespace MyPetsHealthHubApi.Models
{
    public class Vet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Link { get; set; }
        public int? VetUserId { get; set; }
        public VetUser VetUser { get; set; }
    }
}