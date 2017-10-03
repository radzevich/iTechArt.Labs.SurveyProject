using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DAL.EntityModels
{
    public class AnswerDataModel
    {
        public int Id { get; set; }

        [StringLength(512)]
        public string Value { get; set; }
        public int QuestionId { get; set; }   

        public QuestionDataModel Question { get; set; }
    }
}
