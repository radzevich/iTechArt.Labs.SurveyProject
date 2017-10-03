using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DAL.EntityModels
{
    public class QuestionDataModel
    {
        [Key]
        public int Id { get; set; }

        public int TypeId { get; set; }
        public bool IsRequired { get; set; } = false;

        [StringLength(1024)]
        public string Text { get; set; }

        public int? SurveyId { get; set; }
        public int? PageId { get; set; }

        public virtual ICollection<AnswerDataModel> AnswerOptions { get; set; }
        public virtual ICollection<ReceivedAnswer> ReceivedAnswers { get; set; }

        public PageDataModel Page { get; set; }
        public SurveyDataModel Survey { get; set; }

        public QuestionDataModel()
        {
            AnswerOptions = new List<AnswerDataModel>();
            ReceivedAnswers = new List<ReceivedAnswer>();
        }
    }
}
