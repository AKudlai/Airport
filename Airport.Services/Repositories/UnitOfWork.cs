namespace Airport.Services.Repositories
{
    using System;
    using System.Data.Entity;

    using Airport.Contracts;
    using Airport.DAL;
    using Airport.Models.DomainModels.Entities;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext context;

        private bool disposedValue = false;

        private IGenericRpository<Flight> flightsRepository;
        private IGenericRpository<Ticket> ticketsRepository;
        private IGenericRpository<Person> personsRepository;
        private IGenericRpository<Aircraft> aircraftsRepository;
        private IGenericRpository<Port> portsRepository;
        private IGenericRpository<Airline> airlinesRepository;
        private IGenericRpository<FlightStatus> flightStatusRpository;

        public UnitOfWork()
        {
            this.context = new AirportContext();
            this.flightsRepository = new GenericRepository<Flight>(this.context);

            this.ticketsRepository = new GenericRepository<Ticket>(this.context);

            this.personsRepository = new GenericRepository<Person>(this.context);

            this.aircraftsRepository = new GenericRepository<Aircraft>(this.context);

            this.portsRepository = new GenericRepository<Port>(this.context);

            this.airlinesRepository = new GenericRepository<Airline>(this.context);

            this.flightStatusRpository = new GenericRepository<FlightStatus>(this.context);
        }

        public IGenericRpository<Flight> Flights
            => this.flightsRepository ?? (this.flightsRepository = new GenericRepository<Flight>(this.context));

        public IGenericRpository<Ticket> Tickets
            => this.ticketsRepository ?? (this.ticketsRepository = new GenericRepository<Ticket>(this.context));

        public IGenericRpository<Person> Persons
            => this.personsRepository ?? (this.personsRepository = new GenericRepository<Person>(this.context));

        public IGenericRpository<Aircraft> Aircrafts
            => this.aircraftsRepository ?? (this.aircraftsRepository = new GenericRepository<Aircraft>(this.context));

        public IGenericRpository<Port> Ports
            => this.portsRepository ?? (this.portsRepository = new GenericRepository<Port>(this.context));

        public IGenericRpository<Airline> Airlines
            => this.airlinesRepository ?? (this.airlinesRepository = new GenericRepository<Airline>(this.context));

        public IGenericRpository<FlightStatus> FlightStatuses
            => this.flightStatusRpository ?? (this.flightStatusRpository = new GenericRepository<FlightStatus>(this.context));

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
