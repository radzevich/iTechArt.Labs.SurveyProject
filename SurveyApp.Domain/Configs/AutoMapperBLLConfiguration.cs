using AutoMapper;
using SurveyApp.BLL.Configs.AutoMapperProfiles;

namespace SurveyApp.BLL.Configs
{
    public class AutoMapperBLLConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SurveyProfile>();
            });
        }
    }
}