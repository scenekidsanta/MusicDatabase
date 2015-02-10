using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicDatabase.Models
{
    public class Album
    {
            public int AlbumID { get; set; }
            public int ArtistID { get; set; }
            public string AlbumTitle { get; set; }
            public string Genre { get; set; }
            public DateTime ReleaseDate { get; set; }

            public virtual Artist Artist  { get; set; }
            public virtual ICollection<Song> Songs { get; set; }
          
        
    }
}