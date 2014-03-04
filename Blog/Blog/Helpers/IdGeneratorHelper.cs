using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.Helpers
{

    public class IdGenerator
    {
        private static string chars = "ABCDEFGHJKLMNPQRTUVWXYZabcdefghjkmnpqrtuvwxyz";

        public static string RandId(int count)
        {
            var temp = "";
            Random rand = new Random();
            while(count >= 0)
            {
                temp += chars.Substring(rand.Next(chars.Length), 1);
                count--;
            }

            return temp;
        }
    }
}