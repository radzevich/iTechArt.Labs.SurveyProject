using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Interfaces;
using SurveyApp.BLL.Models;
using SurveyApp.WebAPI.Models;

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
        public IEnumerable<CreatedSurveyViewModel> GetAllSurveys(string userId)
        {
            string currentUserId = RequestContext.Principal.Identity.Name;

            IEnumerable<CreatedSurveyServiceModel> surveysServiceModels = SurveyService.GetSurveysCreatedByUser(currentUserId);
            IEnumerable<CreatedSurveyViewModel> surveysForUser = (from survey in surveysServiceModels
                                                                  select Mapper.Map<CreatedSurveyViewModel>(survey))
                                                                  .ToList();
            if (!surveysForUser.Any())
            {
                return new List<CreatedSurveyViewModel>();
                
            }
            return surveysForUser;
        }       

        [HttpPost]
        public async Task<HttpResponseMessage> CreateSurvey(CreatedSurveyViewModel surveyToCreateViewModel)
        {
            string currentUserId = RequestContext.Principal.Identity.Name;
            CreatedSurveyServiceModel surveyToCreateServiceModel = Mapper.Map<CreatedSurveyServiceModel>(surveyToCreateViewModel);

            OperationDetails result = await SurveyService.CreateAsync(surveyToCreateServiceModel, currentUserId);
            if (!result.Succedeed)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> UpdateSurvey(CreatedSurveyViewModel surveyToUpdateViewModel)
        {
            string currentUserId = RequestContext.Principal.Identity.Name;
            UpdatedSurveyServiceModel surveyServiceModel = Mapper.Map<UpdatedSurveyServiceModel>(surveyToUpdateViewModel);

            OperationDetails result = await SurveyService.UpdateAsync(surveyServiceModel, currentUserId);
            if (!result.Succedeed)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> DeleteAsync(int surveyToDeleteId)
        {
            string currentUserId = RequestContext.Principal.Identity.Name;

            OperationDetails result = await SurveyService.RemoveAsync(surveyToDeleteId, currentUserId);
            if (!result.Succedeed)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
