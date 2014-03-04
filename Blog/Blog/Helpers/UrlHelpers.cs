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

namespace BlogSite.Helpers
{
    #region ToSlug(), AsMovedPermanently
    public static class PermanentRedirectionExtensions
    {
        public static PermanentRedirectToRouteResult AsMovedPermanently
            (this RedirectToRouteResult redirection)
        {
            return new PermanentRedirectToRouteResult(redirection);
        }
    }

    public class PermanentRedirectToRouteResult : ActionResult
    {
        public RedirectToRouteResult Redirection { get; private set; }
        public PermanentRedirectToRouteResult(RedirectToRouteResult redirection)
        {
            this.Redirection = redirection;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            // After setting up a normal redirection, switch it to a 301
            Redirection.ExecuteResult(context);
            context.HttpContext.Response.StatusCode = 301;
            context.HttpContext.Response.Status = "301 Moved Permanently";
        }
    }

    public static class StringExtensions
    {
        private static readonly Encoding Encoding = Encoding.GetEncoding("Cyrillic");

        public static string RemoveAccent(this string value)
        {
            byte[] bytes = Encoding.GetBytes(value);
            return Encoding.ASCII.GetString(bytes);
        }

        public static string ToSlug(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            var str = value.RemoveAccent().ToLowerInvariant();

            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            str = Regex.Replace(str, @"\s+", " ").Trim();

            str = str.Substring(0, str.Length <= 200 ? str.Length : 200).Trim();

            str = Regex.Replace(str, @"\s", "-");

            str = Regex.Replace(str, @"-+", "-");

            return str;
        }
    }
    #endregion

    #region UrlEncoder
    /// <summary>
    /// Produces optional, URL-friendly version of a title, "like-this-one". 
    /// hand-tuned for speed, reflects performance refactoring contributed
    /// by John Gietzen (user otac0n) 
    /// </summary>
    public static class UrlEncoder
    {
        public static string URLFriendly(string title)
        {
            if (title == null) return "";

            const int maxlen = 60;
            int len = title.Length;
            bool prevdash = false;
            var sb = new StringBuilder(len);
            char c;

            for (int i = 0; i < len; i++)
            {
                c = title[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
                    prevdash = false;
                }
                else if (c == ' ' || c == ',' || c == '.' || c == '/' ||
                    c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevdash && sb.Length > 0)
                    {
                        sb.Append('-');
                        prevdash = true;
                    }
                }
                else if ((int)c >= 128)
                {
                    int prevlen = sb.Length;
                    sb.Append(RemapInternationalCharToAscii(c));
                    if (prevlen != sb.Length) prevdash = false;
                }
                if (i == maxlen) break;
            }
            if (prevdash) sb.Length -= 1;
            return sb.ToString();
            //1st implementation see: http://stackoverflow.com/questions/25259/how-does-stack-overflow-generate-its-seo-friendly-urls/25486#25486
            //if (prevdash)
            //    return sb.ToString().Substring(0, sb.Length - 1);
            //else
            //    return sb.ToString();
        }

        public static string RemapInternationalCharToAscii(char c)
        {
            string s = c.ToString().ToLowerInvariant();
            if ("àåáâäãåą".Contains(s))
            {
                return "a";
            }
            else if ("èéêëę".Contains(s))
            {
                return "e";
            }
            else if ("ìíîïı".Contains(s))
            {
                return "i";
            }
            else if ("òóôõöøőð".Contains(s))
            {
                return "o";
            }
            else if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }
            else if ("çćčĉ".Contains(s))
            {
                return "c";
            }
            else if ("żźž".Contains(s))
            {
                return "z";
            }
            else if ("śşšŝ".Contains(s))
            {
                return "s";
            }
            else if ("ñń".Contains(s))
            {
                return "n";
            }
            else if ("ýÿ".Contains(s))
            {
                return "y";
            }
            else if ("ğĝ".Contains(s))
            {
                return "g";
            }
            else if (c == 'ř')
            {
                return "r";
            }
            else if (c == 'ł')
            {
                return "l";
            }
            else if (c == 'đ')
            {
                return "d";
            }
            else if (c == 'ß')
            {
                return "ss";
            }
            else if (c == 'Þ')
            {
                return "th";
            }
            else if (c == 'ĥ')
            {
                return "h";
            }
            else if (c == 'ĵ')
            {
                return "j";
            }
            else
            {
                return "";
            }
        }

        //public static string ToFriendlyUrl(this UrlHelper helper,
        //    string urlToEncode)
        //{
        //    urlToEncode = (urlToEncode ?? "").Trim().ToLower();

        //    StringBuilder url = new StringBuilder();

        //    foreach (char ch in urlToEncode)
        //    {
        //        switch (ch)
        //        {
        //            case ' ':
        //                url.Append('-');
        //                break;
        //            case '&':
        //                url.Append("and");
        //                break;
        //            case '\'':
        //                break;
        //            default:
        //                if ((ch >= '0' && ch <= '9') ||
        //                    (ch >= 'a' && ch <= 'z'))
        //                {
        //                    url.Append(ch);
        //                }
        //                else
        //                {
        //                    url.Append('-');
        //                }
        //                break;
        //        }
        //    }

        //    return url.ToString();
        //}

    }

    #endregion

}