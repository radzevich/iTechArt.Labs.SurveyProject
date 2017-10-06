using AutoMapper;
using Ninject;
using Ninject.Modules;

namespace SurveyApp.WebAPI.NinjectModules
{
    public class NinjectAutomapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }

        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.Get(type));
                AutomapperConfig.Register(config);
            });

            Mapper.AssertConfigurationIsValid(); 
            return Mapper.Instance;
        }
    }
}