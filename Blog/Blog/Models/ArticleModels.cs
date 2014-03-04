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
    #region Content Base class
    public class Context
    {
        public Context(){
          Timestamp = DateTime.Now;
    }
      
        [ForeignKey("Blogger")]
        public int UserId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required]
        public virtual string Title { get; set; }
        [Required]
        public virtual string Content { get; set; }
        public bool isPublished { get; set; }
        public DateTime? PublishDate { get; set; }
        [DisplayFormat(DataFormatString = "{0} at {1}")]
        [DataType(DataType.DateTime), Timestamp]
        [ScaffoldColumn(false)]
        public DateTime Timestamp { get; set; }
        [Range(1, 5)]
        public int? StarRating { get; set; }
        public virtual UserProfile Blogger { get; set; }
        public virtual Category Category { get; set; }
        public int RepPoints { get; set; }
        public int? PageViews { get; set; }
        public virtual IList<Vote> Votes { get; set; }
        public virtual IList<Tag> Tags { get; set; }

        private static int GetTimeSpan(DateTime value)
        {
            return value.Subtract(DateTime.Now).Milliseconds;

        }

        public bool HasVoted(int id)
        {
            foreach (var voter in Votes)
            {
                if (voter.VoterId.Equals(id))
                    return true;
            }
            return false;
        }

    }
    #endregion

    #region Vote class
    public class Vote 
    {
        public Vote(int UId, bool up){

            VoterId = UId;
            Voted = true;
            if(up)
                Liked = true;
            else
                  Liked = false;
        }

        public Vote() { }
        
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VoteId { get; set; }
        [ForeignKey("Voter")]
        public int VoterId { get; set; }
        public bool Liked { get; set; }
        public bool Voted { get; set; }
        public virtual UserProfile Voter { get; set; }
    }
    #endregion


    #region Article class
    public class Article : Context
    {
        public Article()
        {
            BadgeLevelEarned = 4;
        }

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }
        [MaxLength(200), MinLength(6)]
        public override string Title { get; set; }
        [Required(ErrorMessage=" * Article has to have some content!"), StringLength(20000, ErrorMessage=" Article must have no more than {0} characters."),MinLengthAttribute(100,ErrorMessage="*Article must have more than {1} characters!")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public override string Content { get; set; }
        public int BadgeLevelEarned { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }    
    }
    public enum PointValues { Article = 1, ArticleUpVote = 20, ArticleDownVote = -10, Comment = 1, Share = 5, AnswerUpVote = 10, AnswerDownVote = -10 }

    #endregion

    #region Question class
    public class Question : Context
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        [MaxLength(200), MinLength(40)]
        public override string Title { get; set; }
        [Required(ErrorMessage = " * Article has to have some content!"), StringLength(2000, ErrorMessage = " Article must have no more than {0} characters."), MinLengthAttribute(100, ErrorMessage = "*Article must have more than {1} characters!")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public override string Content { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
    #endregion

    #region Answer class
    public class Answer : Context
    {
 
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [MaxLength(500), MinLength(40)]
        public override string Title { get; set; }
        [Required(ErrorMessage = " * Cannot post an empty response"), StringLength(1000, ErrorMessage = " * Cannot submit a response with over {1} characters"), MinLength(100, ErrorMessage = "* Is that all you can come up with?")]
        public override string Content { get; set; }
        public virtual Question Question { get; set; }
    }
    #endregion

    #region Ranks class
    public class Ranks
    {
        [Key, ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public static List<int> RankedArticleIds { get; set; }
    }
    #endregion

}