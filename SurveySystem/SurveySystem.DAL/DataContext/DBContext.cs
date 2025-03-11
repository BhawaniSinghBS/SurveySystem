using Microsoft.EntityFrameworkCore;
using SurveySystem.DAL.Entites;

namespace SurveySystem.DAL.DataContext
{
    public class SurveyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<ResponseDetail> ResponseDetails { get; set; }

        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships

            // Question → Options (One-to-Many)
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionID)
                .OnDelete(DeleteBehavior.Cascade); // If a Question is deleted, delete related Options

            // Survey → Questions (One-to-Many)
            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.Survey)
                .HasForeignKey(q => q.SurveyID)
                .OnDelete(DeleteBehavior.Cascade); // If a Survey is deleted, delete related Questions

            // Response → ResponseDetails (One-to-Many)
            modelBuilder.Entity<Response>()
                .HasMany(r => r.ResponseDetails)
                .WithOne(rd => rd.Response)
                .HasForeignKey(rd => rd.ResponseID)
                .OnDelete(DeleteBehavior.Cascade); // If a Response is deleted, delete its details

            // ResponseDetail → Question (One-to-One or Many-to-One)
            modelBuilder.Entity<ResponseDetail>()
                .HasOne(rd => rd.Question)
                .WithMany(q => q.ResponseDetails)
                .HasForeignKey(rd => rd.QuestionID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting Questions if referenced by ResponseDetails

            base.OnModelCreating(modelBuilder);
        }
    }
}
