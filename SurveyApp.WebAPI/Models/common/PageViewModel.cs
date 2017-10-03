namespace SurveyApp.WebAPI.Models.common
{
    public class PageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public QuestionViewModel[] Questions { get; set; }
    }
}