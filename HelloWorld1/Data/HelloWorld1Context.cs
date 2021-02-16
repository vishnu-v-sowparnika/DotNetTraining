using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelloWorld1.Models;

namespace HelloWorld1.Data
{
    public class HelloWorld1Context : DbContext
    {
        public HelloWorld1Context (DbContextOptions<HelloWorld1Context> options)
            : base(options)
        {
        }

        public DbSet<HelloWorld1.Models.Movie> Movie { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
