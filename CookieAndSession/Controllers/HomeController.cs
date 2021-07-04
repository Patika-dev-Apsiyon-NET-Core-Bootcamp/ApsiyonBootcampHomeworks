using CookieAndSession.Extensions;
using CookieAndSession.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CookieAndSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookList _bookList;
        public HomeController(ILogger<HomeController> logger, BookList bookList)
        {
            _logger = logger;
            _bookList = bookList;
         
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetSessionType<BookList>("BookList", _bookList);
            return View();
        }
        public IActionResult IndexWithoutSession()
        {           
            return View("Index");
        }
        public IActionResult Add()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {         
            _bookList.Books.Add(book);
            HttpContext.Session.SetSessionType<BookList>("BookList", _bookList);         
            return RedirectToAction("IndexWithoutSession");

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
    }
}
