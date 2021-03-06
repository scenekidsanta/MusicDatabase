﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicDatabase.DAL;
using MusicDatabase.Models;
using PagedList;
namespace MusicDatabase.Controllers
{
    public class ArtistsController : Controller
    {
        public MusicContext db = new MusicContext();

        // GET: Artists
        public ActionResult Index(string searchString, string sortOrder, string currentFilter)
        {
            
             var artists = from a in db.Artists.Include("Albums") 
                          select a;
             ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

             switch (sortOrder)
             {
                 case "name_desc":
                     artists = artists.OrderByDescending(s => s.ArtistName);
                     break;
             }

             if (!String.IsNullOrEmpty(searchString))
             {
                 artists = artists.Where(s => s.ArtistName.Contains(searchString));
             }

            

            


  var artistVM = new List<ArtistViewModel>();
            foreach(Artist a in artists)
            {
   
                foreach(Album b in a.Albums)
                {
                    artistVM.Add(new ArtistViewModel() {
                                ArtistID = a.ArtistID,ArtistName= a.ArtistName, AlbumTitle= b.AlbumTitle, Genre = b.Genre, ReleaseDate = b.ReleaseDate
                                
                                });
                }
            }


         
            return View(artistVM);
        }
        


        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            
            if (artist == null)
            {
                return HttpNotFound();
            }
           

            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistName, AlbumTitle, Genre, ReleaseDate")] ArtistViewModel artist)
        {
            if (ModelState.IsValid)
            {
                Artist art = new Artist();
                Album alb = new Album();
                    art.ArtistName = artist.ArtistName;
                    alb.AlbumTitle = artist.AlbumTitle;
                    alb.Genre = artist.Genre;
                    alb.ReleaseDate = artist.ReleaseDate;
                    db.Artists.Add(art);
                    db.Albums.Add(alb);
                    db.SaveChanges();
           
                 
               

                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistID,ArtistName")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
