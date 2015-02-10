using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicDatabase.Models;

namespace MusicDatabase.Models
{
    public class ArtistViewModel
    {
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public AlbumViewModel Album { get; set; }


        public class AlbumViewModel
        {
            public string AlbumTitle { get; set; }
            public string Genre { get; set; }
            public DateTime ReleaseDate { get; set; }
        }
    }
}