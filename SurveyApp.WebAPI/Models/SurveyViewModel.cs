using System.ComponentModel.DataAnnotations;
using SurveyApp.WebAPI.Models.common;

namespace SurveyApp.WebAPI.Models
{
    public class SurveyViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public bool IsAnonymous { get; set; }
        public bool IsRandomQuestionOrder { get; set; }
        public bool ShowPagesNumbers { get; set; }
        public bool ShowQuestionsNumbers { get; set; }
        public bool ShowProgressBar { get; set; }
        public bool MarkRequiredFields { get; set; }

        public PageViewModel[] Pages { get; set; }
    }
}