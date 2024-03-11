using Hangfire.Dashboard;

namespace WebAPI.AttributeFilter;

public class HangfireFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        return true;
    }
}