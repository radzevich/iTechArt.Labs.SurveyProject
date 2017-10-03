using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Interfaces;
using SurveyApp.BLL.Models;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Interfaces;

namespace SurveyApp.BLL.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _context;

        private const string AdminRoleName = "admin";
        private const string SurveyNotFoundError = "Survey not found";
        private const string UserNotFoundError = "User not found";
        private const string PermissionDeniedError = "Permission denied";

        public SurveyService(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
        }      

        public async Task<OperationDetails> CreateAsync(CreateSurveyServiceModel surveyToCreate, string creatorName)
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

        public async Task<OperationDetails> UpdateAsync(CreateSurveyServiceModel updatedSurvey)
        {
            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> RemoveAsync(string surveyId, string intiatedByUserId)
        {
            var surveyToDeleteDataModel = _context.Surveys.GetById(surveyId);
            if (surveyToDeleteDataModel != null)
            {
                var surveyToDeleteServiceModel = Mapper.Map<CreateSurveyServiceModel>(surveyToDeleteDataModel);
                if (UserIsAbleToDeleteSurvey(surveyToDeleteDataModel, intiatedByUserId))
                {
                    _context.Surveys.Delete(surveyId);
                    await _context.SaveAsync();

                    return new OperationDetails(true, "", "");
                }  
                return new OperationDetails(false, PermissionDeniedError, "");
            }
            return new OperationDetails(false, SurveyNotFoundError, "");
        }

        public IEnumerable<CreateSurveyServiceModel> GetSurveysCreatedByUser(string userId)
        {
            IEnumerable<SurveyDataModel> userSurveys = _context.Surveys.GetSurveysByCreatorId(userId);
            return new List<CreateSurveyServiceModel>(
                from survey in userSurveys
                select Mapper.Map<CreateSurveyServiceModel>(survey)
            );  
        }

        private bool UserIsAbleToDeleteSurvey(SurveyDataModel surveyToDelete, string userToCheckRightsId)
        {
            if (surveyToDelete.CreatorId != userToCheckRightsId)
            {
                if (_context.UserManager.IsInRole(userToCheckRightsId, AdminRoleName))
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}