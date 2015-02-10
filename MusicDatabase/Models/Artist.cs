using System.Collections.Generic;

namespace MusicDatabase.Models
{
    public class Artist
    {
        
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        
        public virtual ICollection<Album> Albums { get; set; }
    
    }
}