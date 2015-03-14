using MusicDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicDatabase.DAL
{
     public class UnitOfWork : IUnitOfWork
    {
        private MusicContext context = new MusicContext();
        private  IMusicDatabaseRep<Artist> artistRepo;
        private  IMusicDatabaseRep<Album> albumRepo;
        private  IMusicDatabaseRep<Song> songRepo;


        public IMusicDatabaseRep<Models.Artist> ArtistRepo
        {
            get
            {
                if (this.artistRepo == null)
                {
                    this.artistRepo = new MusicDatabaseRepo<Artist>(context);
                }
                return artistRepo;
            }
        }

           public IMusicDatabaseRep<Models.Album> AlbumRepo
        {
            get
            {
                if (this.albumRepo == null)
                {
                    this.albumRepo = new MusicDatabaseRepo<Album>(context);
                }
                return albumRepo;
            }
        }

        public IMusicDatabaseRep<Models.Song> SongRepo
        {
            get
            {
                if (this.songRepo == null)
                {
                    this.songRepo = new MusicDatabaseRepo<Song>(context);
                }
                return songRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
