

namespace SurveySystem.DAL.Entites
{
    public class Option
    {
        public int OptionID { get; set; }
        public int QuestionID { get; set; }
        public string? OptionText { get; set; } = string.Empty;

        // Navigation Property
        public virtual Question Question { get; set; } = null!;
    }
}
