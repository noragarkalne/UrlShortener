namespace UrlShortener.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShortUrls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrlShort = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LongUrls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Short_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShortUrls", t => t.Short_Id)
                .Index(t => t.Short_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LongUrls", "Short_Id", "dbo.ShortUrls");
            DropIndex("dbo.LongUrls", new[] { "Short_Id" });
            DropTable("dbo.LongUrls");
            DropTable("dbo.ShortUrls");
        }
    }
}
