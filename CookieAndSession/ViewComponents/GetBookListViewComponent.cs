using CookieAndSession.Extensions;
using CookieAndSession.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieAndSession.ViewComponents
{
    public class GetBookListViewComponent : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            var data = HttpContext.Session.GetSessionType<BookList>("BookList");
            return View(data.Books);
        }

    }
}
