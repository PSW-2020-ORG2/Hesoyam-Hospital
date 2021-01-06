namespace Authentication.DTOs
{
    public class UserLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public UserLoginDTO(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
