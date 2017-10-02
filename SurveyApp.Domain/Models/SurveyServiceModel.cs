using System;
using SurveyApp.BLL.Models.common;

namespace SurveyApp.BLL.Models
{
    public class SurveyServiceModel
    {
        public string Title { get; set; }

        public string CreatorId { get; set; }
        public DateTime CreationTime { get; set; }

        public string ModifierId { get; set; }
        public DateTime ModificationTime { get; set; }

        public bool IsAnonymous { get; set; }
        public bool IsRandomQuestionOrder { get; set; }
        public bool ShowPagesNumbers { get; set; }
        public bool ShowQuestionsNumbers { get; set; }
        public bool ShowProgressBar { get; set; }
        public bool MarkRequiredFields { get; set; }

        public Page[] Pages { get; set; }
    }
}
