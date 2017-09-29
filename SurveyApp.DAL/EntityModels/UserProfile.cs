using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.DAL.EntityModels
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
 
        public virtual ICollection<SurveyDataModel> Surveys { get; set; }
        public virtual ICollection<CompletedSurvey> CompletedSurveys { get; set; }

        public UserProfile()
        {
            Surveys = new List<SurveyDataModel>();
            CompletedSurveys = new List<CompletedSurvey>();
        }
    }     
}
