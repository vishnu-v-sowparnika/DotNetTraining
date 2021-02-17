using EventManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Controllers
{
    public class LoginController : Controller
    {
        private EventManagementContext _context;
        private ILogger<OrganiserController> _logger;
        public LoginController(EventManagementContext context, ILogger<OrganiserController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Login([FromForm]string email,string password)
        {
            bool flag = true;
            var _result = _context.Organiser.Where(x => x.Email == email && x.Password == password).FirstOrDefault();

            if (_result != null)
            {
                HttpContext.Session.SetInt32("userId", _result.Id);
                return View("Views/Organiser/Index.cshtml", await _context.EventModels.Where(x=>x.organiserId==1).ToListAsync());
            }
            else
            {
                ViewBag.Error = "Invalid Login";
                return View("Views/Login/Index.cshtml");
            }
        }
    }
}
