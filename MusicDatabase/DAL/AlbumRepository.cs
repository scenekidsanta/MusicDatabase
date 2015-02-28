using MusicDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicDatabase.DAL
{
    public class AlbumRepository : IAlbumRepository, IDisposable
    {
        private MusicContext context;

        public AlbumRepository(MusicContext context)
        {
            this.context = context;
        }

        public IEnumerable<Album> GetAlbums()
        {
            return context.Albums.ToList();
        }

        public Album GetAlbumByID(int id)
        {
            return context.Albums.Find(id);
        }

        public void InsertAlbum(Album album)
        {
            context.Albums.Add(album);
        }

        public void DeleteStudent(int albumID)
        {
            Album album = context.Albums.Find(albumID);
            context.Albums.Remove(album);
        }

        public void UpdateStudent(Album album)
        {
            context.Entry(album).State = EntityState.Modified;
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