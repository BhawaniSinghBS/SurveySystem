namespace SurveySystem.DAL.Entites
{
    public class Survey
    {
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public virtual List<Question> Questions { get; set; } = new();
    }
}
