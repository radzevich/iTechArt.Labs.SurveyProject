using AutoMapper;
using SurveyApp.BLL.Configs.AutoMapperProfiles;

namespace SurveyApp.BLL.Configs
{
    public class AutoMapperBLLConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(Configure);
        }

        public static void Configure(IMapperConfigurationExpression config)
        {
            config.AddProfile<SurveyCommonComponentsProfile>();
            config.AddProfile<CreateSurveyProfile>();
        }
    }
}