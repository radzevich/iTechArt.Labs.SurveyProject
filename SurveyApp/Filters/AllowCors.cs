using System.Web.Mvc;

namespace SurveyApp.Filters
{
    public class AllowCors : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("*", "*");
            base.OnActionExecuting(filterContext);
        }
    }
}