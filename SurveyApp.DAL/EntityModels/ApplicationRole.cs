using Microsoft.AspNet.Identity.EntityFramework;

namespace SurveyApp.DAL.EntityModels
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}