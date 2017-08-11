using System.ComponentModel.DataAnnotations;

namespace SinglePageApp.Models
{
    public class AnswerOption
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        [StringLength(512)]
        public string Value { get; set; } 
    }
}
