using SurveyApp.DAL.EntityModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SurveyApp.DAL.DataContext
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationContext>()); 
        }

        public ApplicationContext(string conectionString) : base(conectionString)
        {
        }

        public DbSet<UserProfile> ClientProfiles { get; set; }
        public DbSet<SurveyDataModel> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<ReceivedAnswer> ReceivedAnswers { get; set; }
        public DbSet<CompletedSurvey> CompletedSurveys { get; set; }
    }
}