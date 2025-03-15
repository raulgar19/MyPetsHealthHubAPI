namespace MyPetsHealthHubApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}