using System.Collections.Generic;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using SurveyApp.BLL.Interfaces;
using SurveyApp.BLL.Services;

namespace SurveyApp.CrossLayerConfiguration
{
    public class NinjectConfig
    {
        public static void Register(IKernel kernel)
        {
            
            var modules = new List<INinjectModule>
            {
                new NinjectBllModule(),
            };

            kernel.Load(modules);
        }
    }

    public class NinjectBllModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISurveyService>().To<SurveyService>();
            Bind<IIdentityUserService>().To<IdentityUserService>();
        }
    }
   
}