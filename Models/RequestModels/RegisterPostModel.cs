namespace MyPetsHealthHubApi.Models.RequestModels
{
    public class RegisterPostModel
    {
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public int UserId { get; set; }
    }
}