using Microsoft.AspNet.Identity;
using SurveyApp.DAL.EntityModels;

namespace SurveyApp.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }
}