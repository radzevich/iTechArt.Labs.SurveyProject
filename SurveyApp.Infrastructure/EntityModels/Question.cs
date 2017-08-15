using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Infrastructure.EntityModels
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public int TypeId { get; set; }
        public bool IsRequired { get; set; } = false;

        [StringLength(1024)]
        public string Text { get; set; }

        public int? SurveyId { get; set; }

        public virtual ICollection<AnswerOption> AnswerOptions { get; set; }
        public virtual ICollection<ReceivedAnswer> ReceivedAnswers { get; set; }

        public Page Page { get; set; }
        public Survey Survey { get; set; }

        public Question()
        {
            AnswerOptions = new List<AnswerOption>();
            ReceivedAnswers = new List<ReceivedAnswer>();
        }
    }
}
