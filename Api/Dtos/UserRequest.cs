namespace Api.Dtos
{
    public class UserRequest
    {
        public required string Email { get; set; }
        public string? DisplayName { get; set; }
        public required string Token { get; set; }
    }
}