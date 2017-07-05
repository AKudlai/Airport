using Airport.Models;
using Airport.Models.DomainModels;
using Airport.Models.DomainModels.Entities;

namespace Airport.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRpository<Flight> Flights { get; }
        IGenericRpository<Ticket> Tickets { get; }
        IGenericRpository<Person> Persons { get; }
        IGenericRpository<Price> Prices { get; }
        IGenericRpository<Aircraft> Aircrafts { get; }
        IGenericRpository<Port> Ports { get; }
        IGenericRpository<Airline> Airlines { get; }
        void SaveChanges();
    }
}
