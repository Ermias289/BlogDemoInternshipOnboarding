using BlogDemo.Utils;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;

namespace BlogDemo.Models
{
    public class User : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public string Email { get; set; } = null!;
        [RegularExpression(@"([0-9]){9}$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!; 
        public List<BlogPost> BlogPosts { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
