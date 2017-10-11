using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Models;

namespace SurveyApp.BLL.Services.Interfaces
{
    public interface ISurveyService
    {
        Task<OperationDetails> CreateAsync(DownloadSurveyServiceModel surveyToCreate);
        Task<OperationDetails> UpdateAsync(DownloadSurveyServiceModel updatedSurvey, string modifierName);
        Task<OperationDetails> RemoveAsync(int surveyId, string intiatedByUserId);
        Task<OperationDetails> SaveAsTemplateAsync(DownloadSurveyServiceModel surveyToSaveAsTemplate);
        IEnumerable<UploadSurveyServiceModel> GetSurveysCreatedByUser(string ownerId);
        IEnumerable<UploadSurveyServiceModel> GetSurveysTemplates(string ownerId);
    }
}