using Microsoft.AspNet.Identity;

namespace SurveyApp.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IIdentityUserService CreateIdentityUserService(string connection);
    }
}