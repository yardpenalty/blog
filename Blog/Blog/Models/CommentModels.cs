using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace BlogSite.Models
{
    public class Comment
    {
        // ctor for reply comments
        public Comment(int AId, int UId, int PId)
        {
            isFinalized = false;
            isRoot = false;
            Timestamp = DateTime.Now;
            UserId = UId;
            ArticleId = AId;
            ParentCommentId = PId;
            Content = "";
        }

        //ctor for Root Comments
        public Comment(int AId, int UId)
        {
            isFinalized = false;
            isRoot = true;
            Timestamp = DateTime.Now;
            UserId = UId;
            ArticleId = AId;
            ParentCommentId = null;
            Content = "";
        }

        //ctor for debugging
        public Comment()
        {
            isFinalized = false;
            isRoot = true;
            Timestamp = DateTime.Now;
            UserId = WebSecurity.CurrentUserId;
        }

        [Key]
        public int CommentId { get; set; }
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        [ForeignKey("Commentor")]
        public int UserId { get; set; }
        public int? ParentCommentId { get; set; }
        [DisplayFormat(DataFormatString = "{0:D} at {1}")] //{0:d} or {0:D}
        [DataType(DataType.DateTime), Timestamp]
        [ScaffoldColumn(false)]
        public DateTime Timestamp { get; set; }
        [Required(ErrorMessage=" * Cannot post an empty response"),StringLength(500, ErrorMessage = " * Cannot submit a response with over {1} characters"), MinLength(2,ErrorMessage="* Is that all you can come up with?")]
        public string Content { get; set; }
        public bool isFinalized { get; set; }
        public bool isRoot { get; set; }
        public virtual Article Article { get; set; }
        public virtual IList<Vote> Votes { get; set; }
        public virtual UserProfile Commentor { get; set; }
    }

    public class Rating
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        [Range(1, 5)]
        public int RateValue { get; set; }
        public virtual Answer Answer { get; set; }
    }

    ////public class Question
    //{
    //    [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int QuestionId { get; set; }
    //    [ForeignKey("Blogger")]
    //    public int UserId { get; set; }
    //    [ForeignKey("Category")]
    //    public int CategoryId { get; set; }
    //    [Required]
    //    [MaxLength(100), MinLength(6)]
    //    public string Title { get; set; }
    //    [DisplayFormat(DataFormatString = "{0} at {1}")]
    //    [DataType(DataType.DateTime), Timestamp]
    //    [ScaffoldColumn(false)]
    //    public DateTime Timestamp { get; set; }
    //    [Required(ErrorMessage = " * Article has to have some content!"), StringLength(2000, ErrorMessage = " Article must have no more than {0} characters."), MinLengthAttribute(100, ErrorMessage = "*Article must have more than {1} characters!")]
    //    [UIHint("tinymce_jquery_full"), AllowHtml]
    //    public string Content { get; set; }
    //    public DateTime? PublishDate { get; set; }
    //    public int ArticleRepPoints { get; set; }
    //    public int? PageViews { get; set; }
    //    public virtual UserProfile Blogger { get; set; }
    //    public virtual Category Category { get; set; }
    //    public virtual IList<Tag> Tags { get; set; }
    //    public virtual IList<Answer> Answers { get; set; }
    //}
}