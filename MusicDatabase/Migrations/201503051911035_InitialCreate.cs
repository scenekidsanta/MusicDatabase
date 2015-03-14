namespace MusicDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Song", "Artist_ArtistID", "dbo.Artist");
            DropIndex("dbo.Song", new[] { "Artist_ArtistID" });
            RenameColumn(table: "dbo.Song", name: "Artist_ArtistID", newName: "ArtistID");
            AlterColumn("dbo.Song", "ArtistID", c => c.Int(nullable: false));
            CreateIndex("dbo.Song", "ArtistID");
            AddForeignKey("dbo.Song", "ArtistID", "dbo.Artist", "ArtistID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Song", new[] { "ArtistID" });
            AlterColumn("dbo.Song", "ArtistID", c => c.Int());
            RenameColumn(table: "dbo.Song", name: "ArtistID", newName: "Artist_ArtistID");
            CreateIndex("dbo.Song", "Artist_ArtistID");
            AddForeignKey("dbo.Song", "Artist_ArtistID", "dbo.Artist", "ArtistID");
        }
    }
}
