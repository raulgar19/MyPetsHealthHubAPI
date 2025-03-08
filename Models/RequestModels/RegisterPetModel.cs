namespace MyPetsHealthHubApi.Models.RequestModels
{
    public class RegisterPetModel
    {
        public string Chip { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Weight { get; set; }
        public string Gender { get; set; }
        public string? Notes { get; set; }
        public DateTime? LastVaccination { get; set; }
        public int UserId { get; set; }
    }
}