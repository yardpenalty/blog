using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Mvc;

namespace BlogSite.Helpers
{
    #region Breaks down DateTime to Tue Oct 21, 2003 11:17 am
    ///<summary>
    /// This is a static helper
    ///</summary>
    public static class DateTimeDecoder
    {
        public static string DateTimePicker(DateTime date)
        {
            string s;


            TimeSpan diff = DateTime.Now - date;
            if (diff.TotalHours < 24)
            {
                if (diff.TotalHours >= 1)
                {
                    if (diff.TotalMinutes == 0 && diff.TotalSeconds > 0)
                    {
                        s = string.Format(
                                      CultureInfo.CurrentCulture,
                                      "{0} hours and {1} seconds ago",
                                      diff.Hours,
                                      diff.Seconds);
                    }

                    else
                    {
                        s = string.Format(
                                      CultureInfo.CurrentCulture,
                                      "{0} hours, {1} minutes, and {2} seconds ago",
                                      diff.Hours,
                                      diff.Minutes,
                                      diff.Seconds);
                    }

                }
                else
                {
                    s = string.Format(
                                 CultureInfo.CurrentCulture,
                                 "{0} minutes and {1} seconds ago",
                                 diff.Minutes,
                                 diff.Seconds);

                }
            }
            else
            {

                string day, MMMddyyyy, HHmmsstt;
                day = date.ToString("ddd") + " ";
                MMMddyyyy = date.ToString("MMM dd, yyyy");
                HHmmsstt = date.ToString("h:mm:ss tt");
                s = day + MMMddyyyy + " at " + HHmmsstt;
            }

            return s;
        }

    #endregion

        #region Date Only
        public static string DatePicker(DateTime date)
        {
            string s, day, MMMddyyyy;

            day = date.ToString("ddd") + " ";
            MMMddyyyy = date.ToString("MMM dd, yyyy");

            return s = day + MMMddyyyy;

        }
        #endregion
    }
    #region Convert timezone

    #endregion
    #region IComparer<DateTime>
    // see: DateTime.IComparable.CompareTo
    //http://msdn.microsoft.com/en-us/library/hh924435(v=vs.110).aspx
    // 
    // NOT WORKING>>>FIX ABOVE
    // bool isPublished = DateComparer.Compare(article.PublishDate);
    public class DateComparer
    {

        static bool Compare(DateTime publishDate)
        {
            bool publish;
            if (!publishDate.Date.Equals(DateTime.Now))
            {
                publish = true;
            }
            else
            {
               // if(DateTime.Now.Subtract(publishDate))
                publish = false;
            }

            return publish;
        }
    }
    #endregion
}