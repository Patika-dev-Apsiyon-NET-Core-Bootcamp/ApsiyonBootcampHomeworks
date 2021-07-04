using CookieAndSession.Extensions;
using CookieAndSession.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieAndSession.ViewComponents
{
    public class AddBookViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {           
            return View(new Book());
        }

    }
}
