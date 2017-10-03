namespace SurveyApp.BLL.Models.common
{
    public class PageServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public QuestionServiceModel[] Questions { get; set; }
    }
}