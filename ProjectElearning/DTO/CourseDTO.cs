namespace ProjectElearning.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? LecturesCount { get; set; }
        public int? HourCount { get; set; }
        public int? ViewCount { get; set; }
        public double Price { get; set; }
        public int? Discount { get; set; }
        public double? PromotionPrice { get; set; }
        public string? Description { get; set; }
        public string CourseContent { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
