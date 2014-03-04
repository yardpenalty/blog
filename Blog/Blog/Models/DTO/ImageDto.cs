using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models.DTO
{
    public class ImageDto
    {
        public HttpPostedFileBase Picture { get; set; }
        public string ImageId { get; set; }
    }
}