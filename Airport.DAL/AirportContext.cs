using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Models;

namespace Airport.DAL
{
    public class AirportContext: DbContext
    {
        public AirportContext()
        {
            this.Configuration.LazyLoadingEnabled = false;

        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
