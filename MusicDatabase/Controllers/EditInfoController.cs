using MusicDatabase.DAL;
using MusicDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicDatabase.Controllers
{
      public class EditInfoController : Controller
    {
        IUnitOfWork uow;

        public EditInfoController(IUnitOfWork uow)
        {
            uow = new UnitOfWork();
        }

        // GET: EditInfo
        // This method illustrates using a view model to pass information
        // This example is a bit contrived since we can use List<Author> to do the same thing.
        public ActionResult Index()
        {
            var authors = uow.ArtistRepo.Get(includeProperties: "Albums");

            // Just copying from the entity models to the view model
            var vmList = new List<ArtistViewModel>();
            foreach(Artist a in authors)
            {
                foreach(Album b in a.Albums)
                {
                    vmList.Add(new ArtistViewModel() {
                                AlbumTitle=b.AlbumTitle, Genre= b.Genre, ReleaseDate = b.ReleaseDate,
                                ArtistName = a.ArtistName
                                });
                }
            }

            return View(vmList);
        }

        // GET: EditInfo
        // This method shows that we can actually use one of our entity models to pass the same information 
        // that we passed using the view model in the index method.
        public ActionResult List()
        {
            var artists = uow.ArtistRepo.Get(includeProperties: "Albums");
            return View(artists);
        }

        // GET: BooksCrud/Create
        public ActionResult Create()
        {
            var artists = uow.ArtistRepo.Get();

            var artistNames = new List<string>();
            foreach (Artist a in artists)
                artistNames.Add(a.ArtistName);
            ViewBag.artistList = new SelectList(artistNames);

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Year")] ArtistViewModel artistVm, string artist)
        {
            if (ModelState.IsValid)
            {
                Album album = new Album();
                album.AlbumTitle = artistVm.AlbumTitle;
                album.Genre = artistVm.Genre;
                album.ReleaseDate = artistVm.ReleaseDate;

                var anArtist = uow.ArtistRepo.Get(a => a.ArtistName == artist).FirstOrDefault();

                album.ArtistID = anArtist.ArtistID;
                // TODO: Get author object from db by name
                uow.AlbumRepo.Insert(album);
                uow.Save();
                return RedirectToAction("Index");
            }

            return View(artistVm);
        }
    }
}
