namespace BlogDemo.DTOs.UserDTOs
{
    public class AddUserDTOs
    {
        public string? FName { get; set; } = String.Empty;
        public string? LName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
