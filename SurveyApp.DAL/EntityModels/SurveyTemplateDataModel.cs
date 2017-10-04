using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DAL.EntityModels
{
    public class SurveyTemplateDataModel
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        public string CreatorId { get; set; }
        public DateTime CreationTime { get; set; }

        public string ModifierId { get; set; }
        public DateTime ModificationTime { get; set; }

        public virtual ICollection<PageDataModel> Pages { get; set; }
        public virtual ICollection<QuestionDataModel> Questions { get; set; }

        public virtual UserProfile Creator { get; set; }
        public virtual UserProfile Modifier { get; set; }

        public SurveyTemplateDataModel()
        {
            Pages = new List<PageDataModel>();
            Questions = new List<QuestionDataModel>();
        }
    }
}