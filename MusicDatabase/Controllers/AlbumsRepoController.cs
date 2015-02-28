using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicDatabase.DAL;
using MusicDatabase.Models;

namespace MusicDatabase.Controllers
{
    public class AlbumsRepoController : Controller
    {
        private IAlbumRepository albumRepository;

      public AlbumsRepoController()
      {
         this.albumRepository = new AlbumRepository(new MusicContext());
      }

        // GET: AlbumsRepo
        public ActionResult Index()
        {
            var albums = from s in albumRepository.GetStudents()
                         select s;
            return View(albums.ToList());
        }

        // GET: AlbumsRepo/Details/5
       public ViewResult Details(int id)
      {
         Album album = albumRepository.GetAlbumByID(id);
         return View(album);
      }

        // GET: AlbumsRepo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlbumsRepo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumID,ArtistID,AlbumTitle,Genre,ReleaseDate")] Album album)
        {
            if (ModelState.IsValid)
            {
                albumRepository.InsertAlbum(album);
                albumRepository.Save();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: AlbumsRepo/Edit/5
        public ActionResult Edit(int id)
        {
            Album album = albumRepository.GetAlbumByID(id);
            return View(album);

        }

        // POST: AlbumsRepo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumID,ArtistID,AlbumTitle,Genre,ReleaseDate")] Album album)
        {
            if (ModelState.IsValid)
            {
                albumRepository.UpdateAlbum(album);
                albumRepository.Save();
                return RedirectToAction("Index");
            }
            return View(album);
        }


        // GET: AlbumsRepo/Delete/5
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Album album = albumRepository.GetAlbumByID(id);
            return View(album);
        }

        // POST: AlbumsRepo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Album album = albumRepository.GetAlbumByID(id);
                albumRepository.DeleteAlbum(id);
                albumRepository.Save();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                albumRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
