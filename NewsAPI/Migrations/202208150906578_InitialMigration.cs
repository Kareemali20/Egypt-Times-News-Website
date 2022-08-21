namespace NewsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 30),
                        newsDescription = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Age = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 10),
                        Phone = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserNews",
                c => new
                    {
                        News_ID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.News_ID, t.User_ID })
                .ForeignKey("dbo.News", t => t.News_ID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.News_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNews", "User_ID", "dbo.User");
            DropForeignKey("dbo.UserNews", "News_ID", "dbo.News");
            DropIndex("dbo.UserNews", new[] { "User_ID" });
            DropIndex("dbo.UserNews", new[] { "News_ID" });
            DropTable("dbo.UserNews");
            DropTable("dbo.User");
            DropTable("dbo.News");
        }
    }
}
