using System;
using System.Collections.Generic;

namespace SurveyApp.DAL.EntityModels
{
    public class CompletedSurvey
    {
        public int Id { get; set; }

        public int SurveyId { get; set; } 
        public int UserId { get; set; }        
        public DateTime Date { get; set; }

        public UserProfile User { get; set; }
        public Survey Survey { get; set; }

        public virtual ICollection<ReceivedAnswer> ReceivedAnswers { get; set; }

        public CompletedSurvey()
        {
            ReceivedAnswers = new List<ReceivedAnswer>();
        }
    }
}
