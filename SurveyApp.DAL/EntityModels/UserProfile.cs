using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SurveyApp.DAL.EntityModels
{
    public class UserProfile : IdentityUser
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Name { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
 
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<CompletedSurvey> CompletedSurveys { get; set; }

        public UserProfile()
        {
            Surveys = new List<Survey>();
            CompletedSurveys = new List<CompletedSurvey>();
        }
    }     
}
