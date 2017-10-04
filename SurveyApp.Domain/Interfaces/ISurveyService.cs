using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Models;

namespace SurveyApp.BLL.Interfaces
{
    public interface ISurveyService
    {
        Task<OperationDetails> CreateAsync(CreatedSurveyServiceModel surveyToCreate, string creatorName);
        Task<OperationDetails> UpdateAsync(SurveyServiceModel updatedSurvey, string modifierName);
        Task<OperationDetails> RemoveAsync(int surveyId, string intiatedByUserId);
        Task<OperationDetails> SaveAsTemplateAsync(CreatedSurveyServiceModel surveyToSave, string creatorName);
        IEnumerable<SurveyServiceModel> GetSurveysCreatedByUser(string ownerId);
        IEnumerable<SurveyServiceModel> GetSurveysTemplates(string ownerId);
    }
}