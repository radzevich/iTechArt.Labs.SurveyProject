﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Services.Interfaces;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Models.common;
using SurveyApp.WebAPI.Models;

namespace SurveyApp.WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/survey")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SurveyController : ApiController
    {
        private const string MvcAccountControllerUri = "http://localhost:1169/Account/GetCurrentUserName";

        public ISurveyService SurveyService { get; }
        public IIdentityUserService UserService { get; }
        public IMapper Mapper { get; }

        public SurveyController(ISurveyService surveyService, IIdentityUserService userService, IMapper mapper)
        {
            SurveyService = surveyService;
            UserService = userService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            if (SurveyService != null)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
        }

        [HttpGet]
        [Route("auth")]
        public HttpResponseMessage GetUser()
        {
            if (User != null)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
        }

        [HttpGet]
        [Route("getall/{templatesOnly:bool}")]
        public IEnumerable<CreatedSurveyViewModel> GetAllSurveys(bool templatesOnly)
        {
            string currentUserId = RequestContext.Principal.Identity.Name;

            IEnumerable<SurveyServiceModel> surveysServiceModels = (templatesOnly)
                ? SurveyService.GetSurveysTemplates(currentUserId)
                : SurveyService.GetSurveysCreatedByUser(currentUserId);

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
        [Route("create")]
        public async Task<HttpResponseMessage> CreateSurvey(CreatedSurveyViewModel surveyToCreateViewModel)
        {
            //if (await UserService.IsUserExists(surveyToCreateViewModel.CreatorId))
            //{
            try
            {
                CreatedSurveyServiceModel surveyToCreateServiceModel =
                    Mapper.Map<CreatedSurveyServiceModel>(surveyToCreateViewModel);

                //TODO: Remove second parameter (surveyToCreateServiceModel) already contains creatoId.
                OperationDetails result = await SurveyService.CreateAsync(surveyToCreateServiceModel, surveyToCreateViewModel.CreatorId);
                if (!result.Succedeed)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
                
            //}
            //else
            //{
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            //}
        }

        [HttpPost]
        [Route("update")]
        public async Task<HttpResponseMessage> UpdateSurvey(CreatedSurveyViewModel surveyToUpdateViewModel)
        {
            string currentUserId = RequestContext.Principal.Identity.Name;
            SurveyServiceModel surveyServiceModel = Mapper.Map<SurveyServiceModel>(surveyToUpdateViewModel);

            OperationDetails result = await SurveyService.UpdateAsync(surveyServiceModel, currentUserId);
            if (!result.Succedeed)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
        [Route("delete")]
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

        [HttpPost]
        [Route("saveAsTemplate")]
        public async Task<HttpResponseMessage> SaveSurveyAsTemplate(CreatedSurveyServiceModel surveyToSaveAsTemplate)
        {
            string currentUserId = RequestContext.Principal.Identity.Name;
            CreatedSurveyServiceModel surveyToCreateServiceModel =
                Mapper.Map<CreatedSurveyServiceModel>(surveyToSaveAsTemplate);

            OperationDetails result = await SurveyService.SaveAsTemplateAsync(surveyToCreateServiceModel, currentUserId);
            if (!result.Succedeed)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
