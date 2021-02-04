using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelloWorld1.Data;
using HelloWorld1.Models;

namespace HelloWorld1.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly HelloWorld1.Data.HelloWorld1Context _context;

        public IndexModel(HelloWorld1.Data.HelloWorld1Context context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
