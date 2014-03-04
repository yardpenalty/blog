namespace BlogSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onw33 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vote", "Answer_AnswerId", "dbo.Answer");
            DropForeignKey("dbo.Vote", "Question_QuestionId", "dbo.Question");
            DropForeignKey("dbo.Vote", "Article_ArticleId", "dbo.Article");
            DropIndex("dbo.Vote", new[] { "Answer_AnswerId" });
            DropIndex("dbo.Vote", new[] { "Question_QuestionId" });
            DropIndex("dbo.Vote", new[] { "Article_ArticleId" });
            CreateTable(
                "dbo.VoteArticle",
                c => new
                    {
                        Vote_VoteId = c.Int(nullable: false),
                        Article_ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vote_VoteId, t.Article_ArticleId })
                .ForeignKey("dbo.Vote", t => t.Vote_VoteId, cascadeDelete: true)
                .ForeignKey("dbo.Article", t => t.Article_ArticleId, cascadeDelete: true)
                .Index(t => t.Vote_VoteId)
                .Index(t => t.Article_ArticleId);
            
            CreateTable(
                "dbo.VoteQuestion",
                c => new
                    {
                        Vote_VoteId = c.Int(nullable: false),
                        Question_QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vote_VoteId, t.Question_QuestionId })
                .ForeignKey("dbo.Vote", t => t.Vote_VoteId, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.Question_QuestionId, cascadeDelete: true)
                .Index(t => t.Vote_VoteId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.VoteAnswer",
                c => new
                    {
                        Vote_VoteId = c.Int(nullable: false),
                        Answer_AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vote_VoteId, t.Answer_AnswerId })
                .ForeignKey("dbo.Vote", t => t.Vote_VoteId, cascadeDelete: true)
                .ForeignKey("dbo.Answer", t => t.Answer_AnswerId, cascadeDelete: true)
                .Index(t => t.Vote_VoteId)
                .Index(t => t.Answer_AnswerId);
            
            DropColumn("dbo.Vote", "Answer_AnswerId");
            DropColumn("dbo.Vote", "Question_QuestionId");
            DropColumn("dbo.Vote", "Article_ArticleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vote", "Article_ArticleId", c => c.Int());
            AddColumn("dbo.Vote", "Question_QuestionId", c => c.Int());
            AddColumn("dbo.Vote", "Answer_AnswerId", c => c.Int());
            DropIndex("dbo.VoteAnswer", new[] { "Answer_AnswerId" });
            DropIndex("dbo.VoteAnswer", new[] { "Vote_VoteId" });
            DropIndex("dbo.VoteQuestion", new[] { "Question_QuestionId" });
            DropIndex("dbo.VoteQuestion", new[] { "Vote_VoteId" });
            DropIndex("dbo.VoteArticle", new[] { "Article_ArticleId" });
            DropIndex("dbo.VoteArticle", new[] { "Vote_VoteId" });
            DropForeignKey("dbo.VoteAnswer", "Answer_AnswerId", "dbo.Answer");
            DropForeignKey("dbo.VoteAnswer", "Vote_VoteId", "dbo.Vote");
            DropForeignKey("dbo.VoteQuestion", "Question_QuestionId", "dbo.Question");
            DropForeignKey("dbo.VoteQuestion", "Vote_VoteId", "dbo.Vote");
            DropForeignKey("dbo.VoteArticle", "Article_ArticleId", "dbo.Article");
            DropForeignKey("dbo.VoteArticle", "Vote_VoteId", "dbo.Vote");
            DropTable("dbo.VoteAnswer");
            DropTable("dbo.VoteQuestion");
            DropTable("dbo.VoteArticle");
            CreateIndex("dbo.Vote", "Article_ArticleId");
            CreateIndex("dbo.Vote", "Question_QuestionId");
            CreateIndex("dbo.Vote", "Answer_AnswerId");
            AddForeignKey("dbo.Vote", "Article_ArticleId", "dbo.Article", "ArticleId");
            AddForeignKey("dbo.Vote", "Question_QuestionId", "dbo.Question", "QuestionId");
            AddForeignKey("dbo.Vote", "Answer_AnswerId", "dbo.Answer", "AnswerId");
        }
    }
}
