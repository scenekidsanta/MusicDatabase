using MusicDatabase.DAL;
using MusicDatabase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MusicDatabase.Controllers
{
    public class ArtistCrudController : Controller
    {
        // GET: ArtistCrud
        public ActionResult Index()
        {
            MusicContext db = new MusicContext();
            Artist anArtist = (from a in db.Artists
                               select a).FirstOrDefault<Artist>();

            Album anAlbum = (from b in db.Albums
                             where b.ArtistID == anArtist.ArtistID
                             select b).FirstOrDefault<Album>();

            ArtistViewModel artistVM = new ArtistViewModel()
            {
                ArtistName = anArtist.ArtistName,

                Album = new ArtistViewModel.AlbumViewModel
                {
                    AlbumTitle = anAlbum.AlbumTitle,
                    Genre = anAlbum.Genre,
                    ReleaseDate = anAlbum.ReleaseDate

                }
            };

            List<ArtistViewModel> viewModelList = new List<ArtistViewModel>();
            viewModelList.Add(artistVM);
            return View(viewModelList);
        }
    }
}