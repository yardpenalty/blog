using BlogSite.Models;
using BlogSite.Models.DTO;
using BlogSite.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BlogSite.DAL
{
    //role provider interfacing...read http://martinfowler.com/bliki/InterfaceImplementationPair.html for
    // more about role versus header interfacing

    public interface IArticleRepository : IDisposable
    {
        IEnumerable<Article> GetUsersArticlesById(int id);
        IQueryable<ArticleDto> GetArticlesByAuthorId(int id);
        IQueryable<TitleViewModel> GetFeaturedArticles();
       // IQueryable<Article> SearchArticles(string searchString);
        IEnumerable<Article> GetArticlesByUsername(string username);
        //IQueryable<Article> GetArticleByCategory(string category);
        IEnumerable<Comment> GetCommentsByArticleId(int id);
        void InsertComment(Comment comment);
        void DeleteComment(int article, int commentId);
        void UpdateComment(Comment comment, string content);
        string GetCommentContent(int CId);
        Comment GetCommentById(int CId);
        int GetCommentCount(int AId);
        void AddTagByIds(int AId, int TId);
        void SubmitVote(int UId,int AId, bool like);
       // void LikedArticleById(int UId);
        IQueryable<Article> FindArticlesByTagId(int TId);
        Article GetArticleById(int id);
        void CreateArticle(Article article);
        //void EditArticle(Article article);
        void UpdateArticle(Article article);
        //void DeleteArticle(Article article);
        //void VoteOnArticle(Article article, string username, bool answer);
        void AddRepPoints(int AId, PointValues value);
        //IDictionary<int, int> PopulateRanksByCatId(int UId);
    }
}