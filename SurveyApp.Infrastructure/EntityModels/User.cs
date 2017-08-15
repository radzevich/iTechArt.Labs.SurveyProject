using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SurveyApp.Infrastructure.EntityModels
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
 

        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<CompletedSurvey> CompletedSurveys { get; set; }

        public User()
        {
            Surveys = new List<Survey>();
            CompletedSurveys = new List<CompletedSurvey>();
        }
    }     
}
