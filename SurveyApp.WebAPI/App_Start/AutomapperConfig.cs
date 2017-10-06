using System.ComponentModel;
using AutoMapper;
using SurveyApp.BLL.Configs;

namespace SurveyApp.WebAPI
{
    public class AutomapperConfig
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            AutoMapperWebConfiguration.Configure(config);
            AutoMapperBLLConfiguration.Configure(config);
        }
    }
}