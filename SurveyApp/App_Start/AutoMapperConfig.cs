using SurveyApp.BLL.Configs;
using SurveyApp.WebAPI;

namespace SurveyApp
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            AutoMapperBLLConfiguration.Configure();
            AutoMapperWebConfiguration.Configure();
        }
    }
}