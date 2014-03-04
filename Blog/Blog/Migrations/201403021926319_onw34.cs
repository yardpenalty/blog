namespace BlogSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onw34 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VoteArticle", "Vote_VoteId", "dbo.Vote");
            DropForeignKey("dbo.VoteArticle", "Article_ArticleId", "dbo.Article");
            DropForeignKey("dbo.VoteQuestion", "Vote_VoteId", "dbo.Vote");
            DropForeignKey("dbo.VoteQuestion", "Question_QuestionId", "dbo.Question");
            DropForeignKey("dbo.VoteAnswer", "Vote_VoteId", "dbo.Vote");
            DropForeignKey("dbo.VoteAnswer", "Answer_AnswerId", "dbo.Answer");
            DropIndex("dbo.VoteArticle", new[] { "Vote_VoteId" });
            DropIndex("dbo.VoteArticle", new[] { "Article_ArticleId" });
            DropIndex("dbo.VoteQuestion", new[] { "Vote_VoteId" });
            DropIndex("dbo.VoteQuestion", new[] { "Question_QuestionId" });
            DropIndex("dbo.VoteAnswer", new[] { "Vote_VoteId" });
            DropIndex("dbo.VoteAnswer", new[] { "Answer_AnswerId" });
            AddColumn("dbo.Vote", "Answer_AnswerId", c => c.Int());
            AddColumn("dbo.Vote", "Question_QuestionId", c => c.Int());
            AddColumn("dbo.Vote", "Article_ArticleId", c => c.Int());
            AddForeignKey("dbo.Vote", "Answer_AnswerId", "dbo.Answer", "AnswerId");
            AddForeignKey("dbo.Vote", "Question_QuestionId", "dbo.Question", "QuestionId");
            AddForeignKey("dbo.Vote", "Article_ArticleId", "dbo.Article", "ArticleId");
            CreateIndex("dbo.Vote", "Answer_AnswerId");
            CreateIndex("dbo.Vote", "Question_QuestionId");
            CreateIndex("dbo.Vote", "Article_ArticleId");
            DropTable("dbo.VoteArticle");
            DropTable("dbo.VoteQuestion");
            DropTable("dbo.VoteAnswer");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VoteAnswer",
                c => new
                    {
                        Vote_VoteId = c.Int(nullable: false),
                        Answer_AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vote_VoteId, t.Answer_AnswerId });
            
            CreateTable(
                "dbo.VoteQuestion",
                c => new
                    {
                        Vote_VoteId = c.Int(nullable: false),
                        Question_QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vote_VoteId, t.Question_QuestionId });
            
            CreateTable(
                "dbo.VoteArticle",
                c => new
                    {
                        Vote_VoteId = c.Int(nullable: false),
                        Article_ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vote_VoteId, t.Article_ArticleId });
            
            DropIndex("dbo.Vote", new[] { "Article_ArticleId" });
            DropIndex("dbo.Vote", new[] { "Question_QuestionId" });
            DropIndex("dbo.Vote", new[] { "Answer_AnswerId" });
            DropForeignKey("dbo.Vote", "Article_ArticleId", "dbo.Article");
            DropForeignKey("dbo.Vote", "Question_QuestionId", "dbo.Question");
            DropForeignKey("dbo.Vote", "Answer_AnswerId", "dbo.Answer");
            DropColumn("dbo.Vote", "Article_ArticleId");
            DropColumn("dbo.Vote", "Question_QuestionId");
            DropColumn("dbo.Vote", "Answer_AnswerId");
            CreateIndex("dbo.VoteAnswer", "Answer_AnswerId");
            CreateIndex("dbo.VoteAnswer", "Vote_VoteId");
            CreateIndex("dbo.VoteQuestion", "Question_QuestionId");
            CreateIndex("dbo.VoteQuestion", "Vote_VoteId");
            CreateIndex("dbo.VoteArticle", "Article_ArticleId");
            CreateIndex("dbo.VoteArticle", "Vote_VoteId");
            AddForeignKey("dbo.VoteAnswer", "Answer_AnswerId", "dbo.Answer", "AnswerId", cascadeDelete: true);
            AddForeignKey("dbo.VoteAnswer", "Vote_VoteId", "dbo.Vote", "VoteId", cascadeDelete: true);
            AddForeignKey("dbo.VoteQuestion", "Question_QuestionId", "dbo.Question", "QuestionId", cascadeDelete: true);
            AddForeignKey("dbo.VoteQuestion", "Vote_VoteId", "dbo.Vote", "VoteId", cascadeDelete: true);
            AddForeignKey("dbo.VoteArticle", "Article_ArticleId", "dbo.Article", "ArticleId", cascadeDelete: true);
            AddForeignKey("dbo.VoteArticle", "Vote_VoteId", "dbo.Vote", "VoteId", cascadeDelete: true);
        }
    }
}
