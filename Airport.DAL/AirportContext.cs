namespace Airport.DAL
{
    using System.Data.Entity;

    using Airport.DAL.Mapping;
    using Airport.Models.DomainModels.Entities;

    public class AirportContext : DbContext
    {

        static AirportContext()
        {
            Database.SetInitializer(new AirportDbInitializer());
        }

        public AirportContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Aircraft> Aircrafts { get; set; }

        public DbSet<Port> Ports { get; set; }

        public DbSet<Airline> Airlines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FlightMap());
            modelBuilder.Configurations.Add(new AircraftMap());
            modelBuilder.Configurations.Add(new FlightStatusMap());
            modelBuilder.Configurations.Add(new TicketMap());
            modelBuilder.Configurations.Add(new PriceMap());
        }
    }
}
