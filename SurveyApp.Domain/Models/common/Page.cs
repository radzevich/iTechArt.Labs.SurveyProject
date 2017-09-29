namespace SurveyApp.BLL.Models.common
{
    public class Page
    {
        public int PageNum { get; set; }
        public string Title { get; set; }

        public Question[] Questions { get; set; }
    }
}