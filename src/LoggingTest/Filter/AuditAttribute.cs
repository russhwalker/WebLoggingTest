using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace LoggingTest.Filter
{
    public class AuditAttribute : ActionFilterAttribute
    {

        public AuditAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (filterContext.ActionDescriptor.IsDefined(typeof(SkipAuditAttribute), false))
            //{
            //    base.OnActionExecuting(filterContext);
            //    return;
            //}

            var webLog = new Data.WebLog
            {
                Url = filterContext?.RequestContext?.HttpContext?.Request?.Url?.AbsoluteUri ?? string.Empty,
                IpAddress = GetIPAddress(filterContext.RequestContext.HttpContext.Request),
                FormData = JsonConvert.SerializeObject(ParseValues(filterContext.RequestContext.HttpContext.Request.Form)),
                QueryStringData = JsonConvert.SerializeObject(ParseValues(filterContext.RequestContext.HttpContext.Request.QueryString)),
                CreateDate = DateTime.Now,
                UserName = filterContext?.RequestContext?.HttpContext?.User?.Identity?.Name ?? string.Empty
            };

            //Fire and forget.
            Task.Run(() =>
            {
                var logRepository = new Data.LogRepository();
                logRepository.SaveLog(webLog);
            });

            base.OnActionExecuting(filterContext);
        }

        private Dictionary<string, string> ParseValues(NameValueCollection valueCollection)
        {
            var result = new Dictionary<string, string>();
            if (valueCollection != null)
            {
                foreach (string key in valueCollection)
                {
                    if (key == null)
                    {
                        //Querystring or form had no key in the key-value pair
                        continue;
                    }
                    //Potentially skip passwords, sensitive data etc..
                    result.Add(key, valueCollection[key]);
                }
            }
            return result;
        }

        private string GetIPAddress(HttpRequestBase request)
        {
            var result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrWhiteSpace(result))
            {
                result = request.UserHostAddress;
            }
            return result?.Trim() ?? string.Empty;
        }

    }
}