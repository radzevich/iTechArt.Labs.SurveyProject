using System.Collections.Generic;
using Ninject;
using Ninject.Modules;
using SurveyApp.CrossLayerConfiguration.NinjectModules;

namespace SurveyApp.CrossLayerConfiguration
{
    public class NinjectConfig
    {
        public static void Register(IKernel kernel)
        {      
            var modules = new List<INinjectModule>
            {
                new NinjectBllModule(),
                new NinjectDalModule(),
            };

            kernel.Load(modules);
        }
    }
}