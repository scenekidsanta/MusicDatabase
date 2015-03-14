namespace MusicDatabase.Migrations
{
    using MusicDatabase.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicDatabase.DAL.MusicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MusicDatabase.DAL.MusicContext context)
        {
         
            var artists = new List<Artist>
            {
            new Artist{ ArtistName= "Relient K"},
            };

            artists.ForEach(s => context.Artists.AddOrUpdate(p =>p.ArtistName, s));
            context.SaveChanges();

            var Albums = new List<Album>
            {
            new Album{AlbumTitle="MMHHMM", ArtistID=1,Genre= "Rock", ReleaseDate = DateTime.Parse("2005-09-01")},
      
            };
            Albums.ForEach(s => context.Albums.AddOrUpdate(p => p.AlbumTitle, s));
            context.SaveChanges();
            var songs = new List<Song>
            {
            new Song{songName= "Sunny With a High of 75", SongID=1, AlbumID=1, songLength= 3.36},
           
            };
            songs.ForEach(s => context.Songs.AddOrUpdate(p => p.songName, s));
            context.SaveChanges();
        }
        
    }
}
