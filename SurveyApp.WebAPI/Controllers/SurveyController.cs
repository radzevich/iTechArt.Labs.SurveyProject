using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SurveyApp.BLL.Interfaces;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Services;

namespace SurveyApp.WebAPI.Controllers
{
    public class SurveyController : ApiController
    {
        private readonly ISurveyService _surveyService;

        public SurveyController()
        {
            //_surveyService = ServiceCreator.;
        }

        [HttpGet]
        public HttpResponseMessage GetAllSurveys(string userId)
        {
            string currentUserId = RequestContext.Principal.Identity.Name;
            //IEnumerable<SurveyServiceModel> surveysForUser = 
            return null;
        }
    }
}
