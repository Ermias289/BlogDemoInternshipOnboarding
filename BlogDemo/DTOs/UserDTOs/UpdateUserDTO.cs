namespace BlogDemo.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string? FName { get; set; } = string.Empty;

        public string? LName { get; set; } = string.Empty;   
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
