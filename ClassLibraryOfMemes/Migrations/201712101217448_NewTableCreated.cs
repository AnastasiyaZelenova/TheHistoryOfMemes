namespace ClassLibraryOfMemes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memes", "UserName", c => c.String());
            AddColumn("dbo.Memes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memes", "Discriminator");
            DropColumn("dbo.Memes", "UserName");
        }
    }
}
