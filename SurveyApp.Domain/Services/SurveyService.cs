using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Interfaces;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Services.helpers;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Interfaces;

namespace SurveyApp.BLL.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _context;
        private readonly SurveyServiceHelper _helper;

        private const string SurveyNotFoundError = "Survey not found";
        private const string UserNotFoundError = "User not found";
        private const string PermissionDeniedError = "Permission denied";

        public SurveyService(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
            _helper = new SurveyServiceHelper(_context);
        }      

        public async Task<OperationDetails> CreateAsync(CreatedSurveyServiceModel surveyToCreate, string creatorName)
        {
            var surveyDataModel = Mapper.Map<SurveyDataModel>(surveyToCreate);
            var creatorIdentinity = await _context.UserManager.FindByNameAsync(creatorName);
            var creatorProfile = creatorIdentinity.Profile;

            if (creatorProfile != null)
            {
                var surveyToCreateDataModel = Mapper.Map<SurveyDataModel>(surveyToCreate);
                    
                surveyToCreateDataModel.Creator = creatorProfile;
                surveyToCreateDataModel.Modifier = creatorProfile;
                surveyToCreateDataModel.CreationTime = DateTime.Now;
                surveyToCreateDataModel.ModificationTime = surveyToCreateDataModel.CreationTime;

                _context.Surveys.Create(surveyDataModel);
                await _context.SaveAsync();
            }
            else
            {
                return new OperationDetails(false, UserNotFoundError, "");
            }
          
            return new OperationDetails(true, "", "");             
        }

        public async Task<OperationDetails> UpdateAsync(UpdatedSurveyServiceModel updatedSurvey, string modifierName)
        {
            var surveyDataModel = Mapper.Map<SurveyDataModel>(updatedSurvey);

            var modifierIdentinity = await _context.UserManager.FindByNameAsync(modifierName);
            var creatorIdentinity = surveyDataModel.Creator.ApplicationUser;

            if (modifierIdentinity == null)
            {
                return new OperationDetails(false, UserNotFoundError, "");
            }

            if (modifierIdentinity.Id != creatorIdentinity.Id)
            {
                return new OperationDetails(false, PermissionDeniedError, "");
            }

            var surveyToUpdateDataModel = Mapper.Map<SurveyDataModel>(updatedSurvey);

            surveyToUpdateDataModel.Modifier = modifierIdentinity.Profile;
            surveyToUpdateDataModel.ModificationTime = DateTime.Now;
                    
            _context.Surveys.Create(surveyDataModel);
            await _context.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> RemoveAsync(int surveyId, string intiatedByUserId)
        {
            var surveyToDeleteDataModel = _context.Surveys.GetById(surveyId);
            if (surveyToDeleteDataModel == null)
            {
                return new OperationDetails(false, SurveyNotFoundError, "");
            }

            if (!await _helper.UserIsAbleToDeleteSurvey(surveyToDeleteDataModel, intiatedByUserId))
            {
                return new OperationDetails(false, PermissionDeniedError, "");
            }

            _context.Surveys.Delete(surveyId);
            await _context.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public IEnumerable<CreatedSurveyServiceModel> GetSurveysCreatedByUser(string userId)
        {
            IEnumerable<SurveyDataModel> userSurveys = _context.Surveys.GetSurveysByCreatorId(userId);
            return new List<CreatedSurveyServiceModel>(
                from survey in userSurveys
                select Mapper.Map<CreatedSurveyServiceModel>(survey)
            );  
        }
    }
}