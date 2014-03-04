//using System;
//using System.Collections.Generic;
//using System.EnterpriseServices;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Web;
////http://blog.hompus.nl/2011/03/11/make-your-browser-cache-the-output-of-an-httphandler/
//namespace BlogSite.Helpers
//{
//    using System;

//    public class ResourceHandler : IHttpHandler
//    {
//        public void ProcessRequest(HttpContext context)
//  {
//    context.Response.Cache.SetCacheability(HttpCacheability.Public);
//    context.Response.Cache.SetMaxAge(new TimeSpan(1, 0, 0));

//    string imageName = "some path";

//    Resource resource = CmsHttpContext.Current.RootResourceGallery
//                                    .GetByRelativePath(imageName) as Resource;

//    if (resource == null)
//    {
//      // Resource not found
//      context.Response.StatusCode = 404;
//      return;
//    }

//    string rawIfModifiedSince = context.Request.Headers
//                                             .Get("If-Modified-Since");
//    if (string.IsNullOrEmpty(rawIfModifiedSince))
//    {
//      // Set Last Modified time
//      context.Response.Cache.SetLastModified(resource.LastModifiedDate);
//    }
//    else
//    {
//      DateTime ifModifiedSince = DateTime.Parse(rawIfModifiedSince);

//      // HTTP does not provide milliseconds, so remove it from the comparison
//      if (resource.LastModifiedDate.AddMilliseconds(
//                  -resource.LastModifiedDate.Millisecond) == ifModifiedSince)
//      {
//          // The requested file has not changed
//          context.Response.StatusCode = 304;
//          return;
//      }
//    }

//    using (Stream stream = resource.OpenReadStream())
//    {
//      byte[] buffer = new byte[32];
//      while (stream.Read(buffer, 0, 32) > 0)
//      {
//          context.Response.BinaryWrite(buffer);
//      }
//    }
//  }

//        public bool IsReusable
//        {
//            get { return true; }
//        }
//    }
//}
    
