using SurveyApp.BLL.Configs;

namespace SurveyApp
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            AutoMapperBLLConfiguration.Configure();
        }
    }
}