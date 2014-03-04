using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BlogSite.Helpers
{
    #region RegEx sample code
    //
    // string text = "foo       bar";
    // text = Regex.Replace(text, @"\s+", " ");
    // text = "foo bar"
    //This solution works with spaces, tabs, and newline. If you want just spaces, replace '\s' with ' '.
    #endregion

    #region static String method WhiteSpaceHelper.CompactWhitespaces(str);
    //they handle all whitespace chars not only spaces, 
    //trim both leading and trailing whitespaces, 
    //remove extra whitespaces, and all whitespaces are replaced to space char 
    //(so we have uniform space separator).
    public class WhiteSpaceHelper
    {
        public static String CompactWhitespaces(String s)
        {
            StringBuilder sb = new StringBuilder(s);

            CompactWhitespaces(sb);

            return sb.ToString();
        }
        // NOTE: StringBuilder = Array
        public static void CompactWhitespaces(StringBuilder sb)
        {
            if (sb.Length == 0)
                return;

            // set [start] to first not-whitespace char or to sb.Length 
            // break once char is reached (ASCII) = trims initial whitespaces
          
            int start = 0;

            while (start < sb.Length)
            {
                if (Char.IsWhiteSpace(sb[start]))
                    start++;
                else
                    break;
            }

            // if [sb] has only whitespaces, then return empty string

            if (start == sb.Length)
            {
                sb.Length = 0;
                return;
            }

            // set [end] to last not-whitespace char

            int end = sb.Length - 1;

            while (end >= 0)
            {
                if (Char.IsWhiteSpace(sb[end]))
                    end--;
                else
                    break;
            }

            // compact string

            int dest = 0;
            bool previousIsWhitespace = false;

            for (int i = start; i <= end; i++)
            {
                if (Char.IsWhiteSpace(sb[i]))
                {
                    if (!previousIsWhitespace)
                    {
                        previousIsWhitespace = true;
                        sb[dest] = ' ';
                        dest++;
                    }
                }
                else
                {
                    previousIsWhitespace = false;
                    sb[dest] = sb[i];
                    dest++;
                }
            }

            sb.Length = dest;
        }
    }

    #endregion

}