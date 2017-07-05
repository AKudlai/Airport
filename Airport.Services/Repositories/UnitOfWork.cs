using System.Data.Entity;

using Airport.Contracts;
using Airport.DAL;
using Airport.Models.DomainModels;
using Airport.Models.DomainModels.Entities;

namespace Airport.Services.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        private IGenericRpository<Flight> flightsRepository;
        private IGenericRpository<Ticket> ticketsRepository;
        private IGenericRpository<Person> personsRepository;
        private IGenericRpository<Price> pricesRepository;
        private IGenericRpository<Aircraft> aircraftsRepository;
        private IGenericRpository<Port> portsRepository;
        private IGenericRpository<Airline> airlinesRepository;


        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public UnitOfWork()
        {
            this.context = new AirportContext();
            this.flightsRepository = new GenericRepository<Flight>(this.context);
            this.ticketsRepository = new GenericRepository<Ticket>(this.context);
            //this.flightsRepository.Find(e => true, e => e.FlightType);
        }


        public IGenericRpository<Flight> Flights
            => this.flightsRepository ?? (this.flightsRepository = new GenericRepository<Flight>(this.context));
    
        public IGenericRpository<Person> Persons
            => this.personsRepository ?? (this.personsRepository = new GenericRepository<Person>(this.context));

        public IGenericRpository<Ticket> Tickets
            => this.ticketsRepository ?? (this.ticketsRepository = new GenericRepository<Ticket>(this.context));

        public IGenericRpository<Price> Prices
            => this.pricesRepository ?? (this.pricesRepository = new GenericRepository<Price>(this.context));

        public IGenericRpository<Aircraft> Aircrafts
            => this.aircraftsRepository ?? (this.aircraftsRepository = new GenericRepository<Aircraft>(this.context));

        public IGenericRpository<Port> Ports
            => this.portsRepository ?? (this.portsRepository = new GenericRepository<Port>(this.context));

        public IGenericRpository<Airline> Airlines
            => this.airlinesRepository ?? (this.airlinesRepository = new GenericRepository<Airline>(this.context));
    }
}
