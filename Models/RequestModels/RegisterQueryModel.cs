namespace MyPetsHealthHubApi.Models.RequestModels
{
    public class RegisterQueryModel
    {
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string Purpose { get; set; }
        public string? RequiredActions { get; set; }
        public string? PreviewInstructions { get; set; }
        public string? FollowUpActions { get; set; }
        public int VetId { get; set; }
        public int PetId { get; set; }
    }
}