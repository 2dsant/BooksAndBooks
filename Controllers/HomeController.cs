using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BooksAndBooks.Models;
using BooksAndBooks.Database;

namespace BooksAndBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _database;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext database)
        {
            _logger = logger;
            _database = database;
        }

        public IActionResult Index()
        {
            var Books = _database.Books.ToList();
            return View(Books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NewBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _database.Books.Add(book);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            //return Content("" + id);
            Book BookBD = _database.Books.First(Book => Book.Id == id);
            _database.Books.Remove(BookBD);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditModal(int id)
        {
            Book BookBD = _database.Books.First(Book => Book.Id == id);
            return PartialView(BookBD);
        }


        [HttpPost]
        public IActionResult Edit(Book Book)
        {

            Book BookBD = _database.Books.First(Bookdb => Bookdb.Id == Book.Id);
            BookBD.Name = Book.Name;
            BookBD.Author = Book.Author;
            BookBD.PublishYear = Book.PublishYear;
            BookBD.Category = Book.Category;
            BookBD.Description = Book.Description;
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
