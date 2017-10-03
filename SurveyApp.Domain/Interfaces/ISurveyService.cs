using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Models;

namespace SurveyApp.BLL.Interfaces
{
    public interface ISurveyService
    {
        Task<OperationDetails> CreateAsync(CreateSurveyServiceModel surveyToCreate, string creatorName);
        Task<OperationDetails> UpdateAsync(CreateSurveyServiceModel updatedSurvey);
        Task<OperationDetails> RemoveAsync(string surveyId, string intiatedByUserId);
        IEnumerable<CreateSurveyServiceModel> GetSurveysCreatedByUser(string userId);
    }
}