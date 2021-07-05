using Blog.Data.Dal.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Entities;
using _Blog = Blog.Data.Entities.Blog;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {

        private readonly BlogDbContext _blogDbContext;
        public BlogController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        // GET: BlogController
        public ActionResult Index()
        {
            return RedirectToAction("Details");
        }

        // GET: BlogController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model= await _blogDbContext.Blog
                .Include(p => p.Category)
                .Include(p => p.Comment).ToListAsync();
            return View(model);
        }

        // GET: BlogController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryList = null;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(_Blog blog)
        {
            
            await _blogDbContext.Blog.AddAsync(blog);
            ViewBag.Message=(await _blogDbContext.SaveChangesAsync()).ToString()+" kayıt eklendi";            
            return RedirectToAction("Index");
        }

 

        // GET: BlogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
