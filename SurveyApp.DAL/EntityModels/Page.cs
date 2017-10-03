using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.DAL.EntityModels
{
    public class Page
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        public virtual ICollection<QuestionDataModel> Questions { get; set; }

        public Page()
        {
            Questions = new List<QuestionDataModel>();
        }
    }
}
