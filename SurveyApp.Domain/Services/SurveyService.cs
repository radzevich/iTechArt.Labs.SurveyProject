﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Services.Interfaces;
using SurveyApp.BLL.Models;
using SurveyApp.BLL.Services.helpers;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Repositories.Interfaces;

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

        public async Task<OperationDetails> CreateAsync(DownloadSurveyServiceModel surveyToCreate)
        {
            //var creatorIdentinity = await _context.UserManager.FindByNameAsync(surveyToCreate.CreatorId);
            var creatorIdentity = _context.UserManager.Users.Include("Profile").FirstOrDefault();
            var creatorProfile = creatorIdentity.Profile;

            if (creatorProfile != null)
            {
           
                var surveyToCreateDataModel = Mapper.Map<SurveyDataModel>(surveyToCreate);             
                surveyToCreateDataModel.Creator = creatorProfile;

                await Task.Run(() => _context.Surveys.SaveAsync(surveyToCreateDataModel));
            }
            else
            {
                return new OperationDetails(false, UserNotFoundError, "");
            }
          
            return new OperationDetails(true, "", "");             
        }

        public async Task<OperationDetails> UpdateAsync(DownloadSurveyServiceModel updatedSurvey, string modifierName)
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
            surveyToUpdateDataModel.ModificationTime = DateTime.Now;
                    
            _context.Surveys.SaveAsync(surveyDataModel);

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

        public async Task<OperationDetails> SaveAsTemplateAsync(DownloadSurveyServiceModel surveyToSaveAsTemplate)
        {
            //var creatorIdentinity = await _context.UserManager.FindByNameAsync(surveyToCreate.CreatorId);
            var creatorIdentity = _context.UserManager.Users.Include("Profile").FirstOrDefault();
            var creatorProfile = creatorIdentity.Profile;

            if (creatorProfile != null)
            {
                var surveyToSaveAsTemplateDataModel = Mapper.Map<SurveyTemplateDataModel>(surveyToSaveAsTemplate);
                surveyToSaveAsTemplateDataModel.Creator = creatorProfile;

                await Task.Run(() => _context.SurveyTemplates.SaveAsync(surveyToSaveAsTemplateDataModel));
            }
            else
            {
                return new OperationDetails(false, UserNotFoundError, "");
            }

            return new OperationDetails(true, "", "");
        }

        public IEnumerable<UploadSurveyServiceModel> GetSurveysCreatedByUser(string ownerId)
        {
            //TODO: remove expression.
            ownerId = _context.UserManager.Users.FirstOrDefault()?.Id;

            IEnumerable<SurveyDataModel> userSurveys = _context.Surveys.GetSurveysByCreatorId(ownerId);

            return Mapper.Map<List<UploadSurveyServiceModel>>(userSurveys);
        }

        public IEnumerable<UploadSurveyServiceModel> GetSurveysTemplates(string ownerId)
        {
            IEnumerable<SurveyTemplateDataModel> surveysTemplates = _context.SurveyTemplates.GetSurveyTemplatesByCreatorId(ownerId);

            return Mapper.Map<List<UploadSurveyServiceModel>>(surveysTemplates);
        }
    }
}