using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MusicDatabase.Models;

namespace MusicDatabase.DAL
{
    public class MusicInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MusicContext>
    {
        protected override void Seed(MusicContext context)
        {
            var artists = new List<Artist>
            {
            new Artist{ArtistID = 1, ArtistName= "Relient K"},
            };

            artists.ForEach(s => context.Artists.Add(s));
            context.SaveChanges();

            var Albums = new List<Album>
            {
            new Album{AlbumID=1,AlbumTitle="MMHHMM", ArtistID=1,Genre= "Rock", ReleaseDate = DateTime.Parse("2005-09-01")},
      
            };
            Albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();
            var songs = new List<Song>
            {
            new Song{SongID=1, AlbumID=1, songName= "Sunny With a High of 75", songLength= 3.36},
           
            };
            songs.ForEach(s => context.Songs.Add(s));
            context.SaveChanges();
        }
    }
}