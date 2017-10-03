namespace SurveyApp.WebAPI.Models.common
{
    public class QuestionViewModel
    {
        public int TypeId { get; set; }
        public bool IsRequired { get; set; }

        public string Text { get; set; }
        public AnswerViewModel[] Answers { get; set; }
    }
}