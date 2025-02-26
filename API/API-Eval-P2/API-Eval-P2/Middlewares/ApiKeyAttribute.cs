using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace API_Eval_P2.NewFolder
{
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeader = "xapikey";
        private const string ApiKeyValue = "nCSz8vg4if3TAH5IbVkRrbPWikEbf88c"; // Stocker dans `appsettings.json`

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeader, out var extractedApiKey) || extractedApiKey != ApiKeyValue)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }

}
