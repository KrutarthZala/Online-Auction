using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineAuction.Areas;
namespace OnlineAuction.BAL
{
    public class CheckAccess : ActionFilterAttribute, IAuthorizationFilter
    {
        [Area("SEC_User")]
        [Route("SEC_User/[controller]/[action]")]
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
        
            if (filterContext.HttpContext.Session.GetString("UserID") == null)
            {
                filterContext.Result = new RedirectResult("~/SEC_User/SEC_User/Index");
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            filterContext.HttpContext.Response.Headers["Expires"] = "-1";
            filterContext.HttpContext.Response.Headers["Pragma"] = "no-cache";
            base.OnResultExecuting(filterContext);
        }
    }
}
