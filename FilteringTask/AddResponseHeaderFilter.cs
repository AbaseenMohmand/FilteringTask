using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace FilteringTask
{
    public class AddResponseHeaderFilter : IActionFilter
    {
      

        public  void OnActionExecuting(ActionExecutingContext context)
        {
            
         
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            string ActionName = context.RouteData.Values["action"].ToString();
            context.HttpContext.Response.Headers.Add("Action", ActionName);

            string HTTPMethod = context.HttpContext.Request.Method;
            context.HttpContext.Response.Headers.Add("HTTPMethod", HTTPMethod);

            string httpScheme = context.HttpContext.Request.Scheme;
            context.HttpContext.Response.Headers.Add("httpScheme", httpScheme);

            string host = context.HttpContext.Request.Host.ToString();
            context.HttpContext.Response.Headers.Add("host", host);

            string port = context.HttpContext.Request.Host.Port.ToString();
            context.HttpContext.Response.Headers.Add("port", port);

            var watch = new Stopwatch();
            watch.Start();
            Task.Delay(1000).Wait();
            var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
            context.HttpContext.Response.Headers.Add("TimeTakenToExecute", responseTimeForCompleteRequest.ToString());
            watch.Stop();

            string ServerDateAndTime = DateTime.Now.ToString();
            context.HttpContext.Response.Headers.Add("ServerDateAndTime", ServerDateAndTime);
        }
    }
}
