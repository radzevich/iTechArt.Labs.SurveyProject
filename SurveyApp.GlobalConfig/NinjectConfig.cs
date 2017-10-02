using System.Collections.Generic;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using SurveyApp.BLL.Interfaces;
using SurveyApp.BLL.Services;
using SurveyApp.CrossLayerConfiguration.NinjectModules;
using SurveyApp.DAL.Interfaces;
using SurveyApp.DAL.Repositories;

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