namespace MyPetsHealthHubApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int SocialUserId { get; set; }
        public SocialUser SocialUser { get; set; }
    }
}