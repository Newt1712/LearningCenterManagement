using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.AttributeFilter;

public class BasicAuthorizeFilter : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // bool notAllow = true;
        // var isAllowAnomymous = context.Filters.ToList().Any(o => o.ToString().Contains("AllowAnonymous"));
        // if (!isAllowAnomymous)
        // {
        //     var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //     optionsBuilder.UseSqlServer(AppSettings.MSSQLSettings.SQLConn);
        //     using (var dbContext = new ApplicationDbContext(optionsBuilder.Options))
        //     {
        //         var authenStr = context.HttpContext.Request.Headers["Token"].ToString();
        //         if (string.IsNullOrEmpty(authenStr))
        //         {
        //             context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        //             context.Result = new JsonResult(new { Message = "Unauthorize" });
        //             return;
        //         }
        //         try
        //         {
        //             var isExist = dbContext.Account.FirstOrDefault(o => o.UserName == authenStr);
        //
        //             if (isExist != null)
        //             {
        //                 notAllow = false;
        //             }
        //             else
        //             {
        //                 context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        //                 context.Result = new JsonResult(new { Message = "Bạn không có quyền truy cập trang này." });
        //                 return;
        //             }
        //         }
        //         catch (Exception ex)
        //         {
        //             Sentry.SentrySdk.CaptureException(ex);
        //             notAllow = true;
        //         }
        //     }
        //
        //   
        //     if (notAllow)
        //     {
        //         context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        //         context.Result = new JsonResult(new { Message = "Bạn cần đăng nhập để truy cập chức năng này." });
        //         return;
        //     }
        //     await next();
        // }
        // else
        // {
        //     notAllow = false;
        //     await next();
        // }
    }
}