namespace SurveySystem.DAL.Entites
{
    public class ResponseDetail
    {
        public int ResponseDetailID { get; set; }
        public int ResponseID { get; set; }
        public int QuestionID { get; set; }
        public string? AnswerText { get; set; } = string.Empty; // Stores text answer or selected option

        // Navigation Properties
        public virtual Response Response { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
    }
}
