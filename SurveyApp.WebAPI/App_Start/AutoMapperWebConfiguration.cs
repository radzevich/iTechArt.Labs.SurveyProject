using System.ComponentModel;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Ninject;
using SurveyApp.WebAPI.AutoMapperProfiles;

namespace SurveyApp.WebAPI
{
    public class AutoMapperWebConfiguration
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.AddProfile<SurveyProfile>();
            config.AddCollectionMappers();
        }
    }
}