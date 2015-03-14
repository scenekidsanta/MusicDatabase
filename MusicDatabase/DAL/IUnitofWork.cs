using MusicDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.DAL
{
    public interface IUnitOfWork
    {
        IMusicDatabaseRep<Artist> ArtistRepo { get; }
        IMusicDatabaseRep<Album> AlbumRepo { get; }
        IMusicDatabaseRep<Song> SongRepo { get; }
        void Save();
    }
}
