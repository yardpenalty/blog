using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogSite.Models
{
    public class Category
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "This Category already exists or is an invalid Category!")]
        [StringLength(30, ErrorMessage = "Category name must not exceed 30 characters")]
        public string CategoryName { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public Category(string cat)
        {
            this.CategoryName = cat;
        }

        public Category()
        {
            this.CategoryName = "";
        }
    }

    public class Tag
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        [Required(ErrorMessage = "This Tag already exists or is an invalid Category!")]
        [StringLength(20, ErrorMessage = "Tag name must not exceed 20 characters")]
        public string Name { get; set; }
    }


    //IEnumerable Null set Helper
    public static class NullUtility
    {
        public static bool HasAny<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
    }

}