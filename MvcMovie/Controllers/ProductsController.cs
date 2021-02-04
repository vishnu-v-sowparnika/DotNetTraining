using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
namespace MvcMovie.Controllers
{
    public class ProductsController:Controller
    {
        private readonly MvcMovieContext _context;
        public ProductsController(MvcMovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
