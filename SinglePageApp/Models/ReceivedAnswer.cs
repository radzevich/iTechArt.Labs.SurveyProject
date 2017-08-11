namespace SinglePageApp.Models
{
    public class ReceivedAnswer
    {
        public int Id { get; set; }

        public int? QuestionId { get; set; }
        public Question Question { get; set; }

        public string Value { get; set; }

        public int CompletedSurveyId { get; set; }
        public CompletedSurvey CompletedSurvey { get; set; }
    }
}
