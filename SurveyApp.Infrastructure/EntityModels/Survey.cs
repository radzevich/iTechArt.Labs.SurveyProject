using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Infrastructure.EntityModels
{
    public class Survey
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        public int CreatorId { get; set; }
        public DateTime CreationTime { get; set; } 

        public int ModifierId { get; set; }
        public DateTime ModificationTime { get; set; }   

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<CompletedSurvey> CompletedSurveys { get; set; }

        public virtual User Creator { get; set; }
        public virtual User Modifier { get; set; }

        public Survey()
        {
            Questions = new List<Question>();
            CompletedSurveys =new List<CompletedSurvey>();
        }
    }
}
