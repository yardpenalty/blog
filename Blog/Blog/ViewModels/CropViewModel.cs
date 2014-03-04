using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSite.ViewModels
{
    //
    //
    //Install-Package microsoft-web-helpers
    //http://www.askamoeba.com/Opensource/Opensourcedetail/132/Crop-Resize-Upload-Images-in-C-MVC3-MVC4-using-Jquery-Razor

    public class CropViewModel
    {
        [UIHint("ProfileImage")]
        public string ImageUrl { get; set; }

    }

    public class EditorInputModel
    {
        public CropViewModel Profile { get; set; }
        public double Top { get; set; }
        public double Bottom { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
    
}