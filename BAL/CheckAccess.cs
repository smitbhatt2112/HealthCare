
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace HealthCare.BAL
{
    public class CheckAccess : ActionFilterAttribute, IAuthorizationFilter
    {
        //when user id is not  there then it will redirect to login page
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {

            if (filterContext.HttpContext.Session.GetString("UserID") == null)
            {
                filterContext.Result = new RedirectResult("~/User_Master/Index");
            }
        }
        //Once logout we can not go back/previous page , we must login again.
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            filterContext.HttpContext.Response.Headers["Expires"] = "-1";
            filterContext.HttpContext.Response.Headers["Pragma"] = "no-cache";
            base.OnResultExecuting(filterContext);
        }
    }
}
