using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sentry;

namespace CMSCore.AttributeFilter;

public class AppAuthorizeFilter : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var notAllow = true;
        var host = context.HttpContext.Request.Host.Host;
        if (host == "localhost")
        {
            await next();
            return;
        }

        var isAllowAnomymous = context.Filters.Where(o => o.ToString().Contains("AllowAnonymousFilter")).Count() > 0;
        if (!isAllowAnomymous)
        {
            var token = context.HttpContext.Request.Headers["Token"].ToString();
            var userName = context.HttpContext.Request.Headers["UserName"].ToString();
            try
            {
                notAllow = false;
            }
            catch (Exception ex)
            {
                notAllow = true;
                SentrySdk.CaptureException(ex);
            }

            if (notAllow)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new { Message = "Bạn cần đăng nhập để truy cập chức năng này." });
                return;
            }

            await next();
        }
        else
        {
            await next();
        }
    }
}