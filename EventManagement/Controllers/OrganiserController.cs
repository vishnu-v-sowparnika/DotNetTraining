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
using Microsoft.AspNetCore.Http;

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
            var id = HttpContext.Session.GetInt32("userId");
            return View(await _context.EventModels.Where(x => x.Id == id).ToListAsync());
           // return View();
        }

        public IActionResult Create()
        {
            _logger.LogInformation($"Create controller activated for get");
            return View("Create");
        }

        [HttpPost]
        public async Task< IActionResult> Create(OrganiserCreateInputDTO organiser)
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
            var result = await _context.EventModels.Include(x => x.organiser).ToListAsync();
            return View("Views/Home/Index.cshtml", result);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                id = HttpContext.Session.GetInt32("userId");
            }
            var organiser = _context.Organiser.Where(x => x.Id == id).FirstOrDefault();
            var address = _context.Address.Where(x => x.Id == organiser.AddressId).FirstOrDefault();
            OrganiserEditDTO dto = new OrganiserEditDTO()
            {
                Id =organiser.Id,
                Email=organiser.Email,
                Password=organiser.Password,
                FName=organiser.FName,
                LName=organiser.LName,
                Address1=address.Address1,
                Address2=address.Address2,
                City=address.City,
                State=address.State,
                POBOX=address.POBOX
            };
            return View(dto);
            // return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrganiserEditDTO dto)
        {
            int id = dto.Id;
            if (ModelState.IsValid)
            {
                try
                {
                    Organiser organiser = dto.GetOrganiser();
                    var addressId = _context.Organiser.AsNoTracking().Where(x=>x.Id==dto.Id).FirstOrDefault().AddressId;
                    Address add = dto.GetAddress();
                    add.Id = addressId;
                    organiser.Address = add;
                    //_context.Update(add);
                    //await _context.SaveChangesAsync();
                    _context.Update(organiser);
                    await _context.SaveChangesAsync();
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }
            var model = await _context.Organiser.Include(x => x.Address).Where(x => x.Id == id).FirstOrDefaultAsync();
            return View("Details",model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                id = HttpContext.Session.GetInt32("userId");
            }
            else
            {
                id = HttpContext.Session.GetInt32("userId");
            }
            var model = await _context.Organiser.Include(x => x.Address).Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(model);
            // return View();
        }


        public async Task<IActionResult> GetRegisteredParticipants()
        {
            int? id = HttpContext.Session.GetInt32("userId") ;
            var participants = _context.EventModels.Where(x => x.organiserId == id).FirstOrDefault().participants;
            return View("Views/Participants/Index.cshtml",participants);
        }
    }
}
