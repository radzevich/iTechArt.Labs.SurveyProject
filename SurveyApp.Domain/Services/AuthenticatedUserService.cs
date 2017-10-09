using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SurveyApp.BLL.Services.Interfaces;

namespace SurveyApp.BLL.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public string GetUserName(string serverUri)
        {
            Uri mvcApplicationAccoutControllerUri = new Uri(serverUri);

            WebRequest webRequest = WebRequest.Create(mvcApplicationAccoutControllerUri);
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.Method = WebRequestMethods.Http.Get;

            WebResponse webResponse = webRequest.GetResponse();

            string userName;
            using (var stream = new StreamReader(webResponse.GetResponseStream()))
            {
                userName = stream.ReadToEnd();
            }

            return userName;
        }
    }
}
