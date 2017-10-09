using System.Threading.Tasks;

namespace SurveyApp.BLL.Services.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string GetUserName(string serverUri);
    }
}