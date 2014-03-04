using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.HtmlControls;


namespace BlogSite.Helpers
{
    #region MenuExtensions
    public static class MenuExtensions
    {
        // @Html.MenuExtensions.MenuItem(text,action,controller)
        public static MvcHtmlString MenuItem(
            this HtmlHelper htmlHelper,
            string text,
            string action,
            string controller
        )
        {
            var li = new TagBuilder("li");
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentAction = routeData.GetRequiredString("action");
            var currentController = routeData.GetRequiredString("controller");
            if (string.Equals(currentAction, action, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(currentController, controller, StringComparison.OrdinalIgnoreCase))
            {
                li.AddCssClass("active");
            }
            li.InnerHtml = htmlHelper.ActionLink(text, action, controller).ToHtmlString();
            return MvcHtmlString.Create(li.ToString());
        }
    }
    #endregion

    #region LinkExtensions
    public static class LinkExtensions
    {
        public static MvcHtmlString MyActionLink(
            this HtmlHelper htmlHelper,
            string linkText,
            string action,
            string controller
        )
        {
            var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            if (action == currentAction && controller == currentController)
            {
                var anchor = new TagBuilder("a");
                anchor.Attributes["href"] = "#";
               // anchor.AddCssClass("currentPageCSS");
                anchor.SetInnerText(linkText);
                return MvcHtmlString.Create(anchor.ToString());
            }
            return htmlHelper.ActionLink(linkText, action, controller);
        }
    }
    #endregion

    #region CssColorMaker
     public static class CssColorMaker
    {

        private static Random _colorMaker = new Random();
         public static MvcHtmlString ColorMaker(
            this HtmlHelper htmlHelper, string content
        )
         {


             string[] doubleHex = new[] { "d93434", "CCCCCC", "5771FF", "EEE", "FFBBBB", "FFF", "B99", "AACCFF", "33DDFF" };
             string _hexdecimal = "#";
             //string _hex = "#";
             // Build the span tags
             TagBuilder h2 = new TagBuilder("h2");
             h2.InnerHtml = content;

             //for (int i = 0; i < 3; i++){
               _hexdecimal += doubleHex[_colorMaker.Next(0,doubleHex.Count() - 1)];
             //}
             // Change the text color by either adding the style attribute or a class
             h2.MergeAttribute("style", "color:" + _hexdecimal + ";");
             h2.AddCssClass("title-header");
           
             //for (int i = 0; i < 3; i++)
             //{
              //   _hexdecimal += doubleHex[_colorMaker.Next(0, doubleHex.Count() - 1)];
             //}
            // h2.Attributes.Add("text-shadow:", " 1px 0 0 " + _hexdecimal + ";");
            // span.Attributes.Add("color", _hexdecimal);
             return MvcHtmlString.Create(h2.ToString());
         }
    }
}

#endregion

#region votedHelper
public static class VotedAttributeUtility
{

    public static MvcHtmlString VotedCssMaker(
       this HtmlHelper htmlHelper, string arrow,string vote, bool voted
   )
    {
        string up = "vote-up", down = "vote-down";
        // Build the div container
        TagBuilder div = new TagBuilder("div");
        div.AddCssClass(vote);
 
        if (voted) {
            div.GenerateId(arrow);
            div.AddCssClass("yes");
        }
        else
        {
            if(up.Equals(vote))
              div.GenerateId("arrow-green");
            if(down.Equals(vote))
              div.GenerateId("arrow-red");
        }
        
        
        return MvcHtmlString.Create(div.ToString());
    }
}
#endregion