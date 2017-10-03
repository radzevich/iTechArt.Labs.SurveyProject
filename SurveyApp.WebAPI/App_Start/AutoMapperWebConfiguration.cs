using AutoMapper;
using SurveyApp.WebAPI.AutoMapperProfiles;

namespace SurveyApp.WebAPI
{
    public class AutoMapperWebConfiguration
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