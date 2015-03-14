using MusicDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicDatabase.DAL
{
    
          public class FakeUnitOfWork : IUnitOfWork
    {
     
        private  IMusicDatabaseRep<Artist> artistRepo;
        private  IMusicDatabaseRep<Album> albumRepo;
        private  IMusicDatabaseRep<Song> songRepo;

        private List<Artist> artists;
        private List<Album> albums;
        private List<Song> songs;

        public FakeUnitOfWork(List<Artist> a = null, List<Album> b = null, List<Song> e = null)
        {
            if (a == null)
                artists = new List<Artist>();
            else
                artists = a;

            if (b == null)
                albums = new List<Album>();
            else
                albums = b;
            if (e == null)
                songs = new List<Song>();
            else
                songs = e;
        }

                


        public void Save()
        {
            // Nothing to do here
        }

        public void Dispose()
        {
            // Nothing to do here
        }
    }
}
    
