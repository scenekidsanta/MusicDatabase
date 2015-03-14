using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicDatabase.Models;
using System.Collections.Generic;
using MusicDatabase.DAL;
using System.Web.Mvc;
using MusicDatabase.Controllers;

namespace MusicDatabaseTest
{
    [TestClass]
    public class EditInfo_Tests
    {

        const string ArtistName1 = "Relient K", ArtistName2 = "Switchfoot";
        const string AlbumTitle1 = "MMHHMM", AlbumTitle2 = "Nothing is Sound";

        [TestMethod]
        public void EditInfo_Index_Test()
        {
            // arrange
            List<Artist> artists = new List<Artist>();
            List<Album> albums = new List<Album>();
            albums.Add(new Album { AlbumTitle = AlbumTitle1 });
            albums.Add(new Album { AlbumTitle = AlbumTitle2 });
            artists.Add(new Artist { ArtistName = ArtistName1, Albums = albums });

            var uow = new FakeUnitOfWork(artists);
            var target = new EditInfoController(uow);

            // act
            var view = (ViewResult)target.Index();

            // assert
            var viewModels = (List<ArtistViewModel>)view.Model;
            Assert.AreEqual(ArtistName1, viewModels[0].ArtistName);
            Assert.AreEqual(AlbumTitle1, viewModels[0].AlbumTitle);
            Assert.AreEqual(ArtistName1, viewModels[1].ArtistName);
            Assert.AreEqual(ArtistName1, viewModels[1].AlbumTitle);
        }

        [TestMethod]
        public void EditInfo_Create_Test()
        {
            // ** arrange **
            // Make a list with two artists in it
            List<Artist> artists = new List<Artist>();
            artists.Add(new Artist{ ArtistName = ArtistName1, ArtistID = 1 });
            artists.Add(new Artist { ArtistName = ArtistName2, ArtistID = 2 });

            // Make a List with one album in it
            List<Album> albums = new List<Album>();
            albums.Add(new Album { AlbumTitle = AlbumTitle1, ArtistID = 1 });

            // Create a view model with a book to add to the list
            ArtistViewModel avm = new ArtistViewModel { AlbumTitle = AlbumTitle2 };

            // create a controller object as target
            var uow = new FakeUnitOfWork(a: artists, b: albums);
            var target = new EditInfoController(uow);

            // act
            // add a book and with author to the list of books
            target.Create(avm, ArtistName2);

            // assert
            Assert.AreEqual(1, albums[0].ArtistID);
            Assert.AreEqual(AlbumTitle1, albums[0].AlbumTitle);
            Assert.AreEqual(2, albums[1].ArtistID);
            Assert.AreEqual(AlbumTitle2, albums[1].AlbumTitle);
        }
    }
}

