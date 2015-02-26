using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabase.Models
{
    public class Artist
    {
        
        public int ArtistID { get; set; }

        [StringLength(50)]
        public string ArtistName { get; set; }
        [StringLength(50, ErrorMessage = "Artist Name cannot be longer than 50 characters.")]
        
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    
    }
}