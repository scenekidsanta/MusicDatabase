using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicDatabase.Models
{
    public class Album
    {
            public int AlbumID { get; set; }
            public int ArtistID { get; set; }

            [Required]
            [Display(Name = "Album Title")]
            [StringLength(50)]
            public string AlbumTitle { get; set; }


            [Required]
            [Display(Name = "Genre")]
            [StringLength(30)]
            public string Genre { get; set; }



            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Release Date")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
            public DateTime ReleaseDate { get; set; }


            public virtual Artist Artist  { get; set; }
            public virtual ICollection<Song> Songs { get; set; }
          
        
    }
}