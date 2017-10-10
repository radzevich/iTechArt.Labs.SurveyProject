using System.Collections.Generic;

namespace SurveyApp.DAL.EntityModels
{
    public class SurveyDataModel : SurveyBaseDataModel
    {
        public override int Id { get; set; }

        public virtual ICollection<CompletedSurvey> CompletedSurveys { get; set; }

        public SurveyDataModel()
        {
            CompletedSurveys = new List<CompletedSurvey>();
        }
    }
}
