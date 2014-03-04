namespace BlogSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onw32 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vote", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vote", "Id", c => c.Int(nullable: false));
        }
    }
}
