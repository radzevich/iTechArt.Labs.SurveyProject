using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DAL.EntityModels
{
    public class AnswerOption
    {
        public int Id { get; set; }

        [StringLength(512)]
        public string Value { get; set; }
        public int QuestionId { get; set; }   

        public Question Question { get; set; }
    }
}
