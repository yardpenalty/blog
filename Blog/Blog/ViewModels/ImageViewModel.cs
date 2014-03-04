using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BlogSite.ViewModels
{
    public class ImageViewModel
    {
        // Name of the JPG file with the user's picture
        public HttpPostedFileBase Picture { get; set; }
    }

}
