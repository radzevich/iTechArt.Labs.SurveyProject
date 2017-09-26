using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SurveyApp.BLL.Interfaces;
using SurveyApp.BLL.Services;

namespace SurveyApp
{
    public partial class Startup
    {
        private const string ConnectionString = "SurveyContext";

        private readonly IServiceCreator _serviceCreator = new ServiceCreator();

        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<IIdentityUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IIdentityUserService CreateUserService()
        {
            return _serviceCreator.CreateIdentityUserService(ConnectionString);
        }
    }
}