using System.Threading.Tasks;
using SurveyApp.DAL.EntityModels;
using SurveyApp.DAL.Repositories.Interfaces;

namespace SurveyApp.BLL.Services.helpers
{
    public class SurveyServiceHelper
    {
        private const string AdminRoleName = "admin";

        private readonly IUnitOfWork _context;

        public SurveyServiceHelper(IUnitOfWork dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> UserIsAbleToDeleteSurvey(SurveyDataModel surveyToDelete, string userToCheckRightsId)
        {
            if (surveyToDelete.CreatorId != userToCheckRightsId)
            {
                if (await _context.UserManager.IsInRoleAsync(userToCheckRightsId, AdminRoleName))
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}