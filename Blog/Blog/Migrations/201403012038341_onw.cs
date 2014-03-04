namespace BlogSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onw : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        DateJoined = c.DateTime(nullable: false),
                        UserLevel = c.Int(nullable: false),
                        TotalRepPoints = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false),
                        BadgeLevelEarned = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        isPublished = c.Boolean(nullable: false),
                        PublishDate = c.DateTime(),
                        Timestamp = c.DateTime(nullable: false),
                        StarRating = c.Int(),
                        RepPoints = c.Int(nullable: false),
                        PageViews = c.Int(),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ParentCommentId = c.Int(),
                        Timestamp = c.DateTime(nullable: false),
                        Content = c.String(nullable: false, maxLength: 500),
                        isFinalized = c.Boolean(nullable: false),
                        isRoot = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Article", t => t.ArticleId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.ArticleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Content = c.String(nullable: false, maxLength: 2000),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        isPublished = c.Boolean(nullable: false),
                        PublishDate = c.DateTime(),
                        Timestamp = c.DateTime(nullable: false),
                        StarRating = c.Int(),
                        RepPoints = c.Int(nullable: false),
                        PageViews = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 500),
                        Content = c.String(nullable: false, maxLength: 1000),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        isPublished = c.Boolean(nullable: false),
                        PublishDate = c.DateTime(),
                        Timestamp = c.DateTime(nullable: false),
                        StarRating = c.Int(),
                        RepPoints = c.Int(nullable: false),
                        PageViews = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.QuestionId)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Vote",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        VoterId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        LikedArticle = c.Boolean(nullable: false),
                        Voted = c.Boolean(nullable: false),
                        Answer_AnswerId = c.Int(),
                        Question_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.UserProfile", t => t.VoterId)
                .ForeignKey("dbo.Article", t => t.ArticleId)
                .ForeignKey("dbo.Answer", t => t.Answer_AnswerId)
                .ForeignKey("dbo.Question", t => t.Question_QuestionId)
                .Index(t => t.VoterId)
                .Index(t => t.ArticleId)
                .Index(t => t.Answer_AnswerId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Answer_AnswerId = c.Int(),
                        Question_QuestionId = c.Int(),
                        Article_ArticleId = c.Int(),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.Answer", t => t.Answer_AnswerId)
                .ForeignKey("dbo.Question", t => t.Question_QuestionId)
                .ForeignKey("dbo.Article", t => t.Article_ArticleId)
                .Index(t => t.Answer_AnswerId)
                .Index(t => t.Question_QuestionId)
                .Index(t => t.Article_ArticleId);
            
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        AnswerId = c.Int(nullable: false),
                        RateValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Answer", t => t.AnswerId)
                .Index(t => t.AnswerId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rating", new[] { "AnswerId" });
            DropIndex("dbo.Ranks", new[] { "CategoryId" });
            DropIndex("dbo.Tag", new[] { "Article_ArticleId" });
            DropIndex("dbo.Tag", new[] { "Question_QuestionId" });
            DropIndex("dbo.Tag", new[] { "Answer_AnswerId" });
            DropIndex("dbo.Vote", new[] { "Question_QuestionId" });
            DropIndex("dbo.Vote", new[] { "Answer_AnswerId" });
            DropIndex("dbo.Vote", new[] { "ArticleId" });
            DropIndex("dbo.Vote", new[] { "VoterId" });
            DropIndex("dbo.Answer", new[] { "CategoryId" });
            DropIndex("dbo.Answer", new[] { "UserId" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropIndex("dbo.Question", new[] { "CategoryId" });
            DropIndex("dbo.Question", new[] { "UserId" });
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropIndex("dbo.Comment", new[] { "ArticleId" });
            DropIndex("dbo.Article", new[] { "CategoryId" });
            DropIndex("dbo.Article", new[] { "UserId" });
            DropForeignKey("dbo.Rating", "AnswerId", "dbo.Answer");
            DropForeignKey("dbo.Ranks", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Tag", "Article_ArticleId", "dbo.Article");
            DropForeignKey("dbo.Tag", "Question_QuestionId", "dbo.Question");
            DropForeignKey("dbo.Tag", "Answer_AnswerId", "dbo.Answer");
            DropForeignKey("dbo.Vote", "Question_QuestionId", "dbo.Question");
            DropForeignKey("dbo.Vote", "Answer_AnswerId", "dbo.Answer");
            DropForeignKey("dbo.Vote", "ArticleId", "dbo.Article");
            DropForeignKey("dbo.Vote", "VoterId", "dbo.UserProfile");
            DropForeignKey("dbo.Answer", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Answer", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Question", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Question", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Comment", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Comment", "ArticleId", "dbo.Article");
            DropForeignKey("dbo.Article", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Article", "UserId", "dbo.UserProfile");
            DropTable("dbo.Rating");
            DropTable("dbo.Ranks");
            DropTable("dbo.Tag");
            DropTable("dbo.Vote");
            DropTable("dbo.Answer");
            DropTable("dbo.Question");
            DropTable("dbo.Category");
            DropTable("dbo.Comment");
            DropTable("dbo.Article");
            DropTable("dbo.UserProfile");
        }
    }
}
