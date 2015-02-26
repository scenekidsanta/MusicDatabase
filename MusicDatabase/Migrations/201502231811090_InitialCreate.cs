namespace MusicDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        ArtistID = c.Int(nullable: false),
                        AlbumTitle = c.String(nullable: false, maxLength: 50),
                        Genre = c.String(nullable: false, maxLength: 30),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumID)
                .ForeignKey("dbo.Artist", t => t.ArtistID, cascadeDelete: true)
                .Index(t => t.ArtistID);
            
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        SongID = c.Int(nullable: false, identity: true),
                        AlbumID = c.Int(nullable: false),
                        songName = c.String(),
                        songLength = c.Double(nullable: false),
                        Artist_ArtistID = c.Int(),
                    })
                .PrimaryKey(t => t.SongID)
                .ForeignKey("dbo.Album", t => t.AlbumID, cascadeDelete: true)
                .ForeignKey("dbo.Artist", t => t.Artist_ArtistID)
                .Index(t => t.AlbumID)
                .Index(t => t.Artist_ArtistID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "Artist_ArtistID", "dbo.Artist");
            DropForeignKey("dbo.Song", "AlbumID", "dbo.Album");
            DropForeignKey("dbo.Album", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Song", new[] { "Artist_ArtistID" });
            DropIndex("dbo.Song", new[] { "AlbumID" });
            DropIndex("dbo.Album", new[] { "ArtistID" });
            DropTable("dbo.Song");
            DropTable("dbo.Artist");
            DropTable("dbo.Album");
        }
    }
}
