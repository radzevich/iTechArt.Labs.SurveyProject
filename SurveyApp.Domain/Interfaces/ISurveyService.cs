using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Models;

namespace SurveyApp.BLL.Interfaces
{
    public interface ISurveyService
    {
        Task<OperationDetails> CreateAsync(SurveyServiceModel surveyToCreate);
        Task<OperationDetails> UpdateAsync(SurveyServiceModel updatedSurvey);
        Task<OperationDetails> RemoveAsync(string surveyId, string intiatedByUserId);
        IEnumerable<SurveyServiceModel> GetSurveysCreatedByUser(string userId);
    }
}