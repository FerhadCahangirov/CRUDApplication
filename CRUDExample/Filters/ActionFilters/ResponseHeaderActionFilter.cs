using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDExample.Filters.ActionFilters
{
    [AttributeUsage(AttributeTargets.All)]
    public class ResponseHeaderFilterFactoryAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => false;

        private string? Key {  get; set; }
        private string? Value{  get; set; }
        private int Order {  get; set; }

        public ResponseHeaderFilterFactoryAttribute(string key, string value, int order)
        {
            Key = key;
            Value = value;
            Order = order;
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            ResponseHeaderActionFilter filter = serviceProvider.GetRequiredService<ResponseHeaderActionFilter>();
            filter.Key = Key;
            filter.Value = Value;
            filter.Order = Order;
            return filter;
        }
    }

    public class ResponseHeaderActionFilter : IAsyncActionFilter, IOrderedFilter
    {
       
        public string Key;
        public string Value;
        private readonly ILogger<ResponseHeaderActionFilter> _logger;

        public ResponseHeaderActionFilter(ILogger<ResponseHeaderActionFilter> logger)
        {
            _logger = logger;
        }

        public int Order { get; set; }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();

            context.HttpContext.Response.Headers[Key] = Value;
        }
    }
}
