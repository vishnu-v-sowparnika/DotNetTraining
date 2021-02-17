using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagement.Data;
using EventManagement.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using EventManagement.DTO;

namespace EventManagement.Controllers
{
    public class OrganiserController : Controller
    {
        private EventManagementContext _context;
        private ILogger<OrganiserController> _logger;
        public OrganiserController(EventManagementContext context, ILogger<OrganiserController> logger)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventModels.ToListAsync());
           // return View();
        }

        public IActionResult Create()
        {
            _logger.LogInformation($"Create controller activated for get");
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(OrganiserCreateInputDTO organiser)
        {
            _logger.LogInformation($"Create controller activated {organiser.Email}");
            Address address = new Address()
            {
                Address1=organiser.Address1,
                Address2=organiser.Address2,
                City=organiser.City,
                State=organiser.State,
                POBOX=organiser.POBOX
            };
            _context.Address.Add(address);
            _context.SaveChanges();
            Organiser org = new Organiser()
            {
                FName=organiser.FName,
                LName=organiser.LName,
                Email=organiser.Email,
                Password=organiser.Password,
                Address=address
            };

            _context.Organiser.Add(org);
            _context.SaveChanges();
            return View("Views/Home/Index.cshtml");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {

            }
            return View(await _context.EventModels.ToListAsync());
            // return View();
        }
    }
}
