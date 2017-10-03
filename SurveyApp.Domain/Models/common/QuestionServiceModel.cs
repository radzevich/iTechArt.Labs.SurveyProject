namespace SurveyApp.BLL.Models.common
{
    public class QuestionServiceModel
    {
        public int TypeId { get; set; }
        public bool IsRequired { get; set; }

        public string Text { get; set; }
        public AnswerServiceModel[] Answers { get; set; }
    }
}