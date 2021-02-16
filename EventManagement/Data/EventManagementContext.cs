using EventManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Data
{
    public class EventManagementContext : DbContext
    {
        public EventManagementContext(DbContextOptions<EventManagementContext> context): base(context)
        {
            
        }
        public DbSet<Organiser> Organiser { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<EventModel> EventModels { get; set; }
    }
}
