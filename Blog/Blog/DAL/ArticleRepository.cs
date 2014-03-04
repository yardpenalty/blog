using BlogSite.Helpers;
using BlogSite.Models;
using BlogSite.Models.DTO;
using BlogSite.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using WebMatrix.WebData;

namespace BlogSite.DAL
{
    public class ArticleRepository : IArticleRepository, IDisposable, BlogSite.DAL.IArticleRepository1
    {

        private UsersContext context;

        public ArticleRepository(UsersContext context)
        {
            this.context = context;
        }

        #region User rankings by Category key=Category value=userid
        /// <summary>
        /// Region will get user's rank by category for article or user profile
        /// </summary>
        private static Tuple<int, Category, int> KeyValueRankings { get; set; }


        //Article ranking 
        //public int GetArticleRank(int id, int catId)
        //{
        //    int articleRank = 0;
        //    var article = context.Articles.Find(id);
        //    var cat = context.Categories.Find(catId);
        //
        //    return
        //}

        //public IQueryable<int> GetArticleRank(int id, int catId)
        //{
        //    var articles = from a in context.Articles
        //                  where a.CategoryId.Equals(catId)
        //                  group catId by a.Votes into g
        //                  orderby g.Count() descending
        //                 select new { count = g.Count() };

        //}

        #endregion

        #region articles

        public IQueryable<TitleViewModel> GetFeaturedArticles(){
            IQueryable<TitleViewModel> articles = from a in context.Articles
                                                  orderby a.Title
                                                  where a.RepPoints >= 1
                                                  select new TitleViewModel { ArticleId = a.ArticleId, Title = a.Title, PartialContent = a.Content.Substring(0, 200 ), AuthorName = a.Blogger.UserName};
                      
                         
            return articles;
        }
        public void CreateArticle(Article article)
        {
            context.Articles.Add(article);
            Save();
        }

        public IEnumerable<Article> GetUsersArticlesById(int id)
        {
            var articles = from a in context.Articles
                           select a;
            articles = articles.Where(a => a.Blogger.UserId.Equals(id));
            return articles.ToList();
        }

        public Article GetArticleById(int id)
        {
            return context.Articles.Find(id);
        }

        public void UpdateArticle(Article article)
        {
            context.Entry(article).State = EntityState.Modified;
            Save();
        }
       
        //IQueryable<Article> SearchArticles(string searchString);

        public IEnumerable<Article> GetArticlesByUsername(string username)
        {
            var articles = from a in context.Articles
                           where a.Blogger.UserName == username
                           select a;
            // or articles = articles.Where(a => a.Blogger.UserName.Equals(username));       
            return articles.ToList();
        }

        //IQueryable<Article> GetArticleByCategory(string category);

        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<Article, ArticleDto>> AsArticleDto =
            x => new ArticleDto
            {
                Title = x.Title,
                Author = x.Blogger.UserName,
                Category = x.Category,
                Tags = x.Tags
            };

        public IQueryable<ArticleDto> GetArticlesByAuthorId(int id)
        {
            return context.Articles.Where(b => b.Blogger.UserId == id).Select(AsArticleDto);
        }

        #endregion

        #region Comments
        public IEnumerable<Comment> GetCommentsByArticleId(int id)
        {
            List<Comment> tempList = new List<Comment>();
            var article = GetArticleById(id);
            var comments = article.Comments.Where(c => c.ParentCommentId == null).OrderByDescending(c => c.Timestamp);

            foreach (var c in comments)
            {
                if (c.isRoot)
                {
                    tempList.Add(c);
                    // replies
                    foreach (var r in article.Comments.Where(x => x.ParentCommentId == c.CommentId).OrderBy(x => x.Timestamp))
                    {
                        tempList.Add(r);
                    }
                }
            }
            return tempList;
        }

        public void InsertComment(Comment comment)
        {
            Article article = context.Articles.Find(comment.ArticleId);
            UserProfile commenter = context.Users.Find(comment.UserId);
            comment.Content = WhiteSpaceHelper.CompactWhitespaces(comment.Content);
            context.Comments.Add(comment);
            article.Comments.Add(comment);
            article.RepPoints += 1;
            context.Entry(article).State = EntityState.Modified;
            Save();
        }

       public void UpdateComment(Comment comment, string content)
        {

            comment.Content = WhiteSpaceHelper.CompactWhitespaces(content);
            context.Entry(comment).State = EntityState.Modified;
            Save();
        }

       public Comment GetCommentById(int CId)
       {
           Comment comment = context.Comments.Find(CId);

           return comment;
       }

        public int GetCommentCount(int AId)
       {
           return context.Comments.Where(x => x.ArticleId == AId).Count();
       }

       

        public string GetCommentContent(int CId)
        {
            var comment = context.Comments.Find(CId);
            
            return comment.Content.ToString();
        }

        public void DeleteComment(int articleId, int commentId)
        {
            Article article = context.Articles.Find(articleId);
            article.RepPoints -= 1;
            Comment comment = context.Comments.Find(commentId);
            context.Comments.Remove(comment);
            context.Entry(article).State = EntityState.Modified;
            Save();
        }
        #endregion

        #region Tags

        public void AddTagByIds(int AId, int TId){
            Article article = context.Articles.Find(AId);
           Tag tag = context.Tags.Find(TId);
            article.Tags.Add(tag);
            context.Entry(article).State = EntityState.Modified;
            Save();
        }

        public IQueryable<Article> FindArticlesByTagId(int TId)
        {
            IQueryable<Article> articles = from a in context.Articles
                                           from t in a.Tags
                                           where t.TagId == TId
                                           select a;
            return articles;
        }

        #endregion

        //#region vote
        //public void LikeArticleById(int UId)
        //{
        //  //  Vote vote = context.Articles.Votes
        //}

        public void SubmitVote(int UId,int AId, bool like)
        {
            Vote vote = new Vote(UId, like);
                 
            var article = context.Articles.Find(AId);
            context.Votes.Add(vote);
            //context.Articles.Add(article);
            Save();
            
            var voted = context.Votes.Where(d => d.VoterId.Equals(UId)).FirstOrDefault();
            article.Votes.Add((Vote)voted);
           // context.Entry(article).State = EntityState.Modified;
            Save();
        }

        #region Reputation Points
        public void AddRepPoints(int AId, PointValues value)
        {
            Article article = context.Articles.Find(AId);
            article.RepPoints += (int)Enum.Parse(typeof(PointValues), Enum.GetName(typeof(PointValues), value));
            context.Entry(article).State = EntityState.Modified;
            Save();

        }
        #endregion

        //public IDictionary<int, int> PopulateRanksByCatId(int UId)
        //{
        //    var articles =  from a in context.Articles
        //                   where a.ArticleId == UId
        //                    select a;
        //    SortedList<int, int> temp = new SortedList<int, int>();
        //    foreach(var article in )
        //    return 
        //}

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //void DeleteArticle(Article article);
        //void VoteOnArticle(Article article, string username, bool answer);

    }
}

//////http://www.codeproject.com/Articles/653816/Developing-Architecting-and-Testing-Web-Applicatio
//////public interface IDataService
//////{
//////    void CreateSession();
//////    void BeginTransaction();
//////    void CommitTransaction(Boolean closeSession);
//////    void RollbackTransaction(Boolean closeSession);
//////    void CloseSession();
////}