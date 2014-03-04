using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.Helpers
{
   public class Generic{
    public static int GetCount(List<object> obj){
        return obj.Count();
    }
}
    //class CustomStringComparer : IComparer<string>
    //{
    //    private readonly IComparer<string> _baseComparer;
    //    public CustomStringComparer(IComparer<string> baseComparer)
    //    {
    //        _baseComparer = baseComparer;
    //    }

    //    public int Compare(string x, string y)
    //    {
    //        if (_baseComparer.Compare(x, y) == 0)
    //            return 0;

    //        return _baseComparer.Compare(x, y);
    //    }
    //}

}