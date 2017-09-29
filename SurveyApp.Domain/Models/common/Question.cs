namespace SurveyApp.BLL.Models.common
{
    public class Question
    {
        public int TypeId { get; set; }
        public bool IsRequired { get; set; }

        public string Text { get; set; }
        public Answer[] Answers { get; set; }
    }
}