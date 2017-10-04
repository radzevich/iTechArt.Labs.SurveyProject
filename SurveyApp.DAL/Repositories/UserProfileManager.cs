using SurveyApp.DAL.DataContext;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Repositories.Interfaces;

namespace SurveyApp.DAL.Repositories
{
    public class UserProfileManager : Repository<UserProfile>, IUserProfileManager
    {
        public ApplicationContext Database { get; set; }

        public UserProfileManager(ApplicationContext db) : base(db)
        {
            Database = db;
        }

        public void Create(UserProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}