namespace SurveyApp.Domain.Interfaces
{
    public interface IServiceCreator
    {
        IIdentityUserService CreateIdentityUserService(string connection);
    }
}