using SurveyApp.DAL.EntityModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SurveyApp.DAL.DataContext
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        private const string ConnectingString = "SurveyContext";

        static ApplicationContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationContext>()); 
        }

        public ApplicationContext(string conectionString) : base(conectionString)
        {
        }

        public ApplicationContext() : this(ConnectingString)
        {
        }

        public DbSet<UserProfile> ClientProfiles { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<ReceivedAnswer> ReceivedAnswers { get; set; }
        public DbSet<CompletedSurvey> CompletedSurveys { get; set; }
    }
}