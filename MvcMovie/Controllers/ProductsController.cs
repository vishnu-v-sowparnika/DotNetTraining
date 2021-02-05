using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
namespace MvcMovie.Controllers
{
    public class ProductsController:Controller
    {
        private readonly MvcMovieContext _context;
        public ProductsController(MvcMovieContext context)
        {
            _context = context;
        }

         async public  Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,price")] Product prod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prod);
        }
    }
}
