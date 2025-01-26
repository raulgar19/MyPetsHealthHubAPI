namespace MyPetsHealthHubApi.Models
{
    public class ScheduledQuery
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string Purpose { get; set; }
        public string RequiredActions { get; set; }
        public string PreviewInstructions { get; set; }
        public string FollowUpActions { get; set; }
        public int VetId { get; set; }
        public Vet Vet { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}