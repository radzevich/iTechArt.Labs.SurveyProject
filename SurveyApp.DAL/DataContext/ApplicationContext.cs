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
        public DbSet<QuestionDataModel> Questions { get; set; }
        public DbSet<PageDataModel> Pages { get; set; }
        public DbSet<AnswerDataModel> AnswerOptions { get; set; }
        public DbSet<ReceivedAnswer> ReceivedAnswers { get; set; }
        public DbSet<CompletedSurvey> CompletedSurveys { get; set; }
        public DbSet<SurveyTemplateDataModel> SurveyTemplates { get; set; }
    }
}