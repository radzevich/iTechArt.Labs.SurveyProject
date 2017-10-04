using Ninject.Modules;
using SurveyApp.BLL.Services.Interfaces;
using SurveyApp.BLL.Services;

namespace SurveyApp.CrossLayerConfiguration.NinjectModules
{
    public class NinjectBllModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISurveyService>().To<SurveyService>();
            Bind<IIdentityUserService>().To<IdentityUserService>();
        }
    }
}