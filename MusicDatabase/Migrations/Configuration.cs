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
            new Artist{ArtistName= "Relient K"},
            new Artist{ArtistName= "Switchfoot"},
            new Artist{ArtistName= "MXPX"},
            new Artist{ArtistName= "Future of Forestry"},
            new Artist{ArtistName= "Willie Nelson"},

            };

            artists.ForEach(s => context.Artists.AddOrUpdate(p => p.ArtistName, s));
            context.SaveChanges();

            var Albums = new List<Album>
            {
            new Album{AlbumTitle="MMHHMM", ArtistID=1,Genre= "Rock", ReleaseDate = DateTime.Parse("2005-09-01")},
            new Album{AlbumTitle="Nothing is Sound", ArtistID=2,Genre= "Alt-Rock", ReleaseDate = DateTime.Parse("2003-10-14")},
            new Album{AlbumTitle="MXPX", ArtistID=3,Genre= "Punk", ReleaseDate = DateTime.Parse("2000-01-01")},
            new Album{AlbumTitle="Travel I", ArtistID=4,Genre= "Indie", ReleaseDate = DateTime.Parse("2006-01-11")},
            new Album{AlbumTitle="The Long Road", ArtistID=5,Genre= "Country", ReleaseDate = DateTime.Parse("1976-02-01")},
            };
            Albums.ForEach(s => context.Albums.AddOrUpdate(p => p.AlbumTitle, s));
            context.SaveChanges();

             var songs = new List<Song>
             {
             new Song{songName= "Sunny With a High of 75",SongID=1, AlbumID=1, songLength= 3.36},
             
             };
             songs.ForEach(s => context.Songs.AddOrUpdate(p => p.songName, s));
             context.SaveChanges();
         }
         
        }
    }
