using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicDatabase.Models;
using System.Collections.Generic;
using MusicDatabase.Controllers;
using MusicDatabase.DAL;
using System.Web.Mvc;

namespace MusicDatabaseTests
{
  
    [TestClass]
    public class EditInfo_Tests
    {

       const string AUTHOR1_NAME = "Brian Bird", AUTHOR2_NAME = "Dr. Suess";
       const string BOOK1_TITLE = "Programming War Stories", BOOK2_TITLE = "The Cat in the Hat";

        [TestMethod]
        public void EditInfo_Index_Test()
        {
            // arrange
            List<Author> authors = new List<Author>();
            List<Book> books = new List<Book>();
            books.Add(new Book {Title= BOOK1_TITLE});
            books.Add(new Book {Title = BOOK2_TITLE});
            authors.Add(new Author {Name = AUTHOR1_NAME, Books=books});

            var uow = new FakeUnitOfWork(authors);
            var target = new EditInfoController(uow);

            // act
            var view = (ViewResult)target.Index();

            // assert
            var viewModels = (List<BookViewModel>)view.Model;
            Assert.AreEqual(AUTHOR1_NAME, viewModels[0].Author.Name);
            Assert.AreEqual(BOOK1_TITLE, viewModels[0].Title);
            Assert.AreEqual(AUTHOR1_NAME, viewModels[1].Author.Name);
            Assert.AreEqual(BOOK2_TITLE, viewModels[1].Title);
        }

        [TestMethod]
        public void EditInfo_Create_Test()
        {
            // ** arrange **
            // Make a list with two authors in it
            List<Author> authors = new List<Author>();
            authors.Add(new Author {Name=AUTHOR1_NAME, ID=1});
            authors.Add(new Author { Name = AUTHOR2_NAME, ID = 2 });

            // Make a List with one book in it
            List<Book> books = new List<Book>();            
            books.Add(new Book{Title = BOOK1_TITLE, AuthorId=1});

            // Create a view model with a book to add to the list
            BookViewModel bvm = new BookViewModel { Title = BOOK2_TITLE };

            // create a controller object as target
            var uow = new FakeUnitOfWork(a:authors, b: books);
            var target = new EditInfoController(uow);

            // act
            // add a book and with author to the list of books
           target.Create(bvm, AUTHOR2_NAME);

            // assert
            Assert.AreEqual(1, books[0].AuthorId);
            Assert.AreEqual(BOOK1_TITLE, books[0].Title);
            Assert.AreEqual(2, books[1].AuthorId);
            Assert.AreEqual(BOOK2_TITLE, books[1].Title);
        }
    }
}

}
