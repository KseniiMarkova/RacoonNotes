namespace AuthService.Models.Messages
{
    public class GetUserByIdResponceMessage
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsBanned { get; set; }
    }
}
