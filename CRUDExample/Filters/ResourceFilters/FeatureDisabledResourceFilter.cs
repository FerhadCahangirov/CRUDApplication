
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDExample.Filters.ResourceFilters
{
    public class FeatureDisabledResourceFilter : IAsyncResourceFilter
    {
        ILogger<FeatureDisabledResourceFilter> _logger;
        private readonly bool _isDisabled = true;

        public FeatureDisabledResourceFilter(ILogger<FeatureDisabledResourceFilter> logger, bool isDisabled)
        {
            _logger = logger;
            _isDisabled = isDisabled;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            _logger.LogInformation($"{nameof(FeatureDisabledResourceFilter)}.{nameof(OnResourceExecutionAsync)} -- before");

            if (_isDisabled)
            {
                //context.Result = new NotFoundResult();
                context.Result = new StatusCodeResult(501);

            }
            else
            {
                await next();
            }


            _logger.LogInformation($"{nameof(FeatureDisabledResourceFilter)}.{nameof(OnResourceExecutionAsync)} -- after");

        }
    }
}
