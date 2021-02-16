using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloWorld1.Pages.Address
{
    public class IndexModel : PageModel
    {
        public List<Models.Address> address  { get; set; }
        public void OnGet()
        {

            address = new List<Models.Address>
            {
                new Models.Address()
                {
                    Name="Address 1",Pobox="67696"
                },

                new Models.Address()
                {
                    Name="Address 2",Pobox="67697"
                }
            };
        }

        public IActionResult OnPost([FromForm] string name, [FromForm] string pobox)
        {
           
            Models.Address ob = new Models.Address()
            {
                Name = name,
                Pobox = pobox
            };

            address?.Add(ob);

            return RedirectToPage("Index");
        }
    }
}
