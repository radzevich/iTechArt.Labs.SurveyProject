using System.Threading.Tasks;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Models;

namespace SurveyApp.BLL.Interfaces
{
    public interface ISurveyService
    {
        Task<OperationDetails> CreateAsync(SurveyModel surveyToCreate);
        Task<OperationDetails> UpdateAsync(SurveyModel updatedSurvey);
        Task<OperationDetails> RemoveAsync(string surveyId, string intiatedByUserId);
    }
}