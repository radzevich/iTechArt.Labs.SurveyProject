namespace SinglePageApp.Context
{
    using System.Data.Entity;
    using Models;

    public class SurveyContext : DbContext
    {
        static SurveyContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SurveyContext>()); 
        }

        public SurveyContext()
            : base("name=SurveyContext")
        {
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<ReceivedAnswer> ReceivedAnswers { get; set; }
        public DbSet<CompletedSurvey> CompletedSurveys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .HasRequired(f => f.Creator)
                .WithRequiredDependent()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Survey>()
                .HasRequired(f => f.Modifier)
                .WithRequiredDependent()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompletedSurvey>()
                .HasRequired(f => f.User)
                .WithRequiredDependent()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompletedSurvey>()
                .HasRequired(f => f.Survey)
                .WithRequiredDependent()
                .WillCascadeOnDelete(false);
        }
    }
}