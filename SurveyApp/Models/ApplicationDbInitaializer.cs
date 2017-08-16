using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SurveyApp.Models
{
    public class ApplicationDbInitaializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);
        }
    }
}