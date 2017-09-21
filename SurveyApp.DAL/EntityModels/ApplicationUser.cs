using Microsoft.AspNet.Identity.EntityFramework;

namespace SurveyApp.DAL.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfile ClientProfile { get; set; }
    }
}
