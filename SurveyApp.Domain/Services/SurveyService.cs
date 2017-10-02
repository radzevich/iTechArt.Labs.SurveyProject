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
        private const string PermissionDeniedError = "Permission denied";

        public SurveyService(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
        }      

        public async Task<OperationDetails> CreateAsync(SurveyServiceModel surveyToCreate)
        {
            try
            {
                var surveyDataModel = Mapper.Map<SurveyDataModel>(surveyToCreate);
                _context.Surveys.Create(surveyDataModel);
                await _context.SaveAsync();

                return new OperationDetails(true, "", "");
            }
            catch (Exception e)
            {
                return new OperationDetails(false, e.Message, "");
            }               
        }

        public async Task<OperationDetails> UpdateAsync(SurveyServiceModel updatedSurvey)
        {
            try
            {
                var surveyDataModel = Mapper.Map<SurveyDataModel>(updatedSurvey);
                _context.Surveys.Update(surveyDataModel);
                await _context.SaveAsync();

                return new OperationDetails(true, "", "");
            }
            catch (Exception e)
            {
                return new OperationDetails(false, e.Message, "");
            }
        }

        public async Task<OperationDetails> RemoveAsync(string surveyId, string intiatedByUserId)
        {
            var surveyToDeleteDataModel = _context.Surveys.GetById(surveyId);
            if (surveyToDeleteDataModel != null)
            {
                var surveyToDeleteServiceModel = Mapper.Map<SurveyServiceModel>(surveyToDeleteDataModel);
                if (UserIsAbleToDeleteSurvey(surveyToDeleteServiceModel, intiatedByUserId))
                {
                    _context.Surveys.Delete(surveyId);
                    await _context.SaveAsync();

                    return new OperationDetails(true, "", "");
                }  
                return new OperationDetails(false, PermissionDeniedError, "");
            }
            return new OperationDetails(false, SurveyNotFoundError, "");
        }

        public IEnumerable<SurveyServiceModel> GetSurveysCreatedByUser(string userId)
        {
            IEnumerable<SurveyDataModel> userSurveys = _context.Surveys.GetSurveysByCreatorId(userId);
            return new List<SurveyServiceModel>(
                from survey in userSurveys
                select Mapper.Map<SurveyServiceModel>(survey)
            );  
        }

        private bool UserIsAbleToDeleteSurvey(SurveyServiceModel surveyToDelete, string userToCheckRightsId)
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