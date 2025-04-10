using BlogDemo.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace BlogDemo.Models
{
    public class Review : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string? ReviewString { get; set; }
        public int? Rating { get; set; } = null;
        [JsonIgnore]
        public BlogPost? BlogPost { get; set; }
        [ForeignKey("BlogPostId")]
        public int BlogPostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
