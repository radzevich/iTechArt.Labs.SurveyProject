using System.Threading.Tasks;
using SurveyApp.BLL.Infrastructure;
using SurveyApp.BLL.Interfaces;
using SurveyApp.BLL.Models;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Interfaces;

namespace SurveyApp.BLL.Services
{
    public class SurveyService
    {
        public class SurveyCreator : ISurveyService
        {
            private readonly IUnitOfWork _context;

            public SurveyCreator(IUnitOfWork unitOfWork)
            {
                _context = unitOfWork;
            }

            public Task<OperationDetails> CreateAsync(SurveyModel surveyToCreate)
            {
                SurveyDataModel surveyDataModel = _context.Surveys.
            }

            public Task<OperationDetails> UpdateAsync(SurveyModel updatedSurvey)
            {
                throw new System.NotImplementedException();
            }

            public Task<OperationDetails> RemoveAsync(string surveyId, string intiatedByUserId)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}