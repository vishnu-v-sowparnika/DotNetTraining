using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MvcMovie.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        
        public int ? productTypeId { get; set; }
        
        [ForeignKey("productTypeId")]
        public virtual ProductType productType { get; set; }
    }
}
