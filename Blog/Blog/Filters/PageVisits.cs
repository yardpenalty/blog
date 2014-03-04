using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Filters
{
    public class MyFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            context.RequestContext.HttpContext.Response.Write("<!-- Buuu! -->");
            
        }
    }
}