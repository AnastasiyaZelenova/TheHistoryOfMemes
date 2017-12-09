namespace ClassLibraryOfMemes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectionRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MemeGroups", "Meme_Id", "dbo.Memes");
            DropForeignKey("dbo.MemeGroups", "Group_Id", "dbo.Groups");
            DropIndex("dbo.MemeGroups", new[] { "Meme_Id" });
            DropIndex("dbo.MemeGroups", new[] { "Group_Id" });
            DropTable("dbo.MemeGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MemeGroups",
                c => new
                    {
                        Meme_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meme_Id, t.Group_Id });
            
            CreateIndex("dbo.MemeGroups", "Group_Id");
            CreateIndex("dbo.MemeGroups", "Meme_Id");
            AddForeignKey("dbo.MemeGroups", "Group_Id", "dbo.Groups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MemeGroups", "Meme_Id", "dbo.Memes", "Id", cascadeDelete: true);
        }
    }
}
