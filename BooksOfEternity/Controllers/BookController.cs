using Microsoft.AspNetCore.Mvc;

namespace BooksOfEternity.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Details(string bookId)
        {
            return View("Details");
        }
    }
}