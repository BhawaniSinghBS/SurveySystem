
namespace SurveySystem.DAL.Entites
{
    public class Response
    {
        public int ResponseID { get; set; }
        public int SurveyID { get; set; }
        public int UserID { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdatedAt { get; set; } // For Editing Responses

        // Navigation Properties
        public virtual Survey Survey { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual List<ResponseDetail> ResponseDetails { get; set; } = new();
    }
}
