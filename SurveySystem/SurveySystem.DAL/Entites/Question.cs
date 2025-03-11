using SurveySystem.Shared;

namespace SurveySystem.DAL.Entites
{
    public class Question
    {
        public int QuestionID { get; set; }
        public int SurveyID { get; set; }
        public string? QuestionText { get; set; } = string.Empty;
        public QuestionType QuestionType { get; set; } // Enum for question type
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual Survey Survey { get; set; } = null!;
        public virtual List<Option>? Options { get; set; } // Only for Multiple Choice
        public virtual ICollection<ResponseDetail> ResponseDetails { get; set; } = new List<ResponseDetail>();
    }
}
