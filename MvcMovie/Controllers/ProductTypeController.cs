using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcMovie.Models;
using MvcMovie.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MvcMovie.Controllers

{
    public class ProductTypeController : Controller
    {
        private readonly MvcMovieContext _context;

        public ProductTypeController (MvcMovieContext context)
        {
            _context = context;
        }
        // GET: ProductTypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("description")]ProductType type)
        {
            try
            {
                _context.ProductType.Add(type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(await _context.ProductType.ToListAsync());
            }
        }

        // GET: ProductTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductTypeController/Edit/5
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

        // GET: ProductTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductTypeController/Delete/5
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
