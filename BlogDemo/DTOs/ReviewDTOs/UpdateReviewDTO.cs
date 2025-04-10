namespace BlogDemo.DTOs.ReviewDTOs
{
    public class UpdateReviewDTO
    {
        public int Id { get; set; }
        public string ReviewString { get; set; }
        public int? Rating { get; set; } = null;
    }
}
