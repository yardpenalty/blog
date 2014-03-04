using BlogSite;
using BlogSite.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;

namespace BlogSite
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    //
    //
    // NOTE: When a virtual path is present in production environment 
    // ie: ~/Article is production and /RootDir/Article...
    //                                      
    // var wrongAbsPath = "~/RootDir/Article..
    //
    // var relativePath = wrongAbsPath.Remove(0, HttpContext.Current.Request.ApplicationPath.Length);
    //
    // = "/RootDir/Article..

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            // Register global filter for PageVisits
            GlobalFilters.Filters.Add(new MyFilterAttribute());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
         
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection(
                   "BlogSiteConnection",
                   "UserProfile",
                   "UserId",
                   "UserName", autoCreateTables: true);
            }
        }
    }
}