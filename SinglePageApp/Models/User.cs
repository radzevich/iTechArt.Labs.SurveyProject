using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SinglePageApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(320)]
        public string Email { get; set; }
        [StringLength(20)]
        public string PasswordHash { get; set; }
        [StringLength(20)]
        public string Status { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<CompletedSurvey> CompletedSurveys { get; set; }

        public User()
        {
            Surveys = new List<Survey>();
            CompletedSurveys = new List<CompletedSurvey>();
        }
    }     
}
