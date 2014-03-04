using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BlogSite.Helpers;
using System.Text;

namespace BlogSite
{
   
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Article controller
            // http://localhost:64915/Article/6/returning-a-partial-view-using-ajaxbeginform/
            routes.MapRoute(
            null,
            "Article/{id}/{title}",
            new { controller = "Article", action = "Details"},
            new { id = @"\d+", title = @"[\w\-]*" });
            // reroutes from  http://localhost:64915/Article/6/ to http://localhost:64915/Article/6/returning-a-partial-view-using-ajaxbeginform/
            routes.MapRoute(
                null,
                "Article/{id}",
                new { controller = "Article", action = "Details" },
                new { id = @"\d+"});

            // Question controller
            // http://localhost:64915/Question/6/returning-a-partial-view-using-ajaxbeginform/
            //routes.MapRoute(
            //null,
            //"Question/{id}/{title}",
            //new { controller = "Question", action = "Details" },
            //new { id = @"\d+", title = @"[\w\-]*" });
            //// reroutes from  http://localhost:64915/Article/6/ to http://localhost:64915/Article/6/returning-a-partial-view-using-ajaxbeginform/
            //routes.MapRoute(
            //    null,
            //    "Article/{id}",
            //    new { controller = "Question", action = "Details" },
            //    new { id = @"\d+" });

            // News controller
            // http://localhost:64915/News/Sports/is-tom-brady-the-greatest-of-all-time?
            //routes.MapRoute(
            //null,
            //"News/{Category}/{title}/{timestamp}",
            //new { controller = "News", action = "Details" },
            //new { title = @"[\w\-]*",timestamp = "/^[0-9]{4}-[0-9]{2}-[0-9]{2}$/" });

            //routes.MapRoute(
            //null,
            //"News/{Category}/{title}",
            //new { controller = "News", action = "Details" },
            //new { title = @"[\w\-]*" });

            //WORKING!
            // reroutes from  http://localhost:64915/Article/6/ to http://localhost:64915/Article/6/returning-a-partial-view-using-ajaxbeginform/
            routes.MapRoute(
                null,
                "Article/{id}",
                new { controller = "Question", action = "Details" },
                new { id = @"\d+" });
          
            //Home controller
            routes.MapRoute(
               "Default", // Route name
               "{controller}/{action}/{id}", // URL with parameters
               new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
           );


        }
    }
}