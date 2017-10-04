using SurveyApp.BLL.Models.common;

namespace SurveyApp.BLL.Models
{
    public class SurveyServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsAnonymous { get; set; }
        public bool IsRandomQuestionOrder { get; set; }
        public bool ShowPagesNumbers { get; set; }
        public bool ShowQuestionsNumbers { get; set; }
        public bool ShowProgressBar { get; set; }
        public bool MarkRequiredFields { get; set; }

        public PageServiceModel[] Pages { get; set; }
    }
}