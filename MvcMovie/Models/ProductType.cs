using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MvcMovie.Models
{
    public class ProductType
    {
      
        public int id { get; set; }
        public string description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
