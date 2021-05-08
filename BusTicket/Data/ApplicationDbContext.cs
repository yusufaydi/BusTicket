using BusTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<User> User { get; set; }
        public DbSet<Bus> Bus { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Route> Route { get; set; }

    }
}
