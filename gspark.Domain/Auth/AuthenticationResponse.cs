using System.Text.Json.Serialization;

namespace gspark.Domain.Auth
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public string JWTtoken { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
