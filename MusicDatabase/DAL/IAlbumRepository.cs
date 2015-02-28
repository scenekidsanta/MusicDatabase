using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicDatabase.Models;

namespace MusicDatabase.DAL
{
    
    
        public interface IAlbumRepository : IDisposable
        {
            IEnumerable<Album> GetStudents();
            Album GetAlbumByID(int AlbumID);
            void InsertAlbum(Album album);
            void DeleteAlbum(int AlbumID);
            void UpdateAlbum(Album album);
            void Save();
        }
    }
}