using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicDatabase.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public int AlbumID { get; set; }
        public string songName { get; set; }
        public double songLength { get; set; }
        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
    }
}