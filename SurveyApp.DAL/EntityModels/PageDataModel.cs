using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DAL.EntityModels
{
    public class PageDataModel
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        public int SurveId { get; set; }
        public SurveyDataModel Survey { get; set; }

        public virtual ICollection<QuestionDataModel> Questions { get; set; }

        public PageDataModel()
        {
            Questions = new List<QuestionDataModel>();
        }
    }
}
