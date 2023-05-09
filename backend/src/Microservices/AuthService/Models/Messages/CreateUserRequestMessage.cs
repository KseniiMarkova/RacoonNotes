namespace AuthService.Models.Messages
{
    public class CreateUserRequestMessage
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RegistrationCountry { get; set; }
    }
}
