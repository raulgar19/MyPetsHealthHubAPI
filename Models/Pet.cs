namespace MyPetsHealthHubApi.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Chip { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Weight { get; set; }
        public string Gender { get; set; }
        public string Notes { get; set; }
        public DateTime? LastVaccination { get; set; }
        public int? PetCardId { get; set; }
        public PetCard PetCard { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int? VetId { get; set; }
        public Vet Vet { get; set; }
    }
}