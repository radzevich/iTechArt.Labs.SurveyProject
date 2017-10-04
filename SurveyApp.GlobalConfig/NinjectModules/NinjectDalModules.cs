using Ninject.Modules;
using SurveyApp.DAL.Repositories.Interfaces;
using SurveyApp.DAL.Repositories;

namespace SurveyApp.CrossLayerConfiguration.NinjectModules
{
    public class NinjectDalModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}