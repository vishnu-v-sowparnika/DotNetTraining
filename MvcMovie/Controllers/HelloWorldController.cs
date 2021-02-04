using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }

        //public String Index()
        //{
        //    return "This is default action ... ";
        //}
        public String Welcome(string name,int num)
        {
            //return "This is the welcome action method ...";
            return HtmlEncoder.Default.Encode($"Hello {name} , NumTimes is : {num}");
        }
    }
}
