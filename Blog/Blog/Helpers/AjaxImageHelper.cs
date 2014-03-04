using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace BlogSite.Helpers
{
    #region xxx
    public static class ImageActionLinkHelper
    {
        public static string ImageActionLink(this AjaxHelper helper, string imageUrl, string altText, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);
            builder.MergeAttribute("alt", altText);
            var link = helper.ActionLink("[replaceme]", actionName, routeValues, ajaxOptions).ToString();
            return link.Replace("[replaceme]", builder.ToString(TagRenderMode.SelfClosing));
        }
        //@Ajax.ImageActionLink("../../Content/Delete.png", "Delete", "Delete", new { id = item.Id }, new AjaxOptions { Confirm = "Delete contact?", HttpMethod = "Delete", UpdateTargetId = "divContactList" })
    }
  

           
  

    

    #endregion

}