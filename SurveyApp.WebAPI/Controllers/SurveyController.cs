using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using SurveyApp.BLL.Interfaces;
using SurveyApp.BLL.Models;

namespace SurveyApp.WebAPI.Controllers
{
    [Authorize]
    public class SurveyController : ApiController
    {
        public ISurveyService SurveyService { get; }

        public SurveyController(ISurveyService surveyService)
        {
            SurveyService = surveyService;
        }

        [HttpGet]
        public IEnumerable<CreateSurveyServiceModel> GetAllSurveys(string userId)
        {
            string currentUserId = RequestContext.Principal.Identity.Name;
            IEnumerable<CreateSurveyServiceModel> surveysForUser = SurveyService.GetSurveysCreatedByUser(currentUserId);
            if (surveysForUser != null)
            {
                return surveysForUser;
            }
            else
            {
                return new List<CreateSurveyServiceModel>();
            }
        }

        [HttpPost]
        public void CreateSurvey(CreateSurveyServiceModel surveyToCreateModel)
        {
            string currentUserId = RequestContext.Principal.Identity.Name;
           // surveyToCreateModel.CreatorId = currentUserId;

            //SurveyService.CreateAsync(surveyToCreateModel);
        }
    }
}
