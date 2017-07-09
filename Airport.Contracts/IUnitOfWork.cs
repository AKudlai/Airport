namespace Airport.Contracts
{
    using Airport.Models.DomainModels.Entities;

    public interface IUnitOfWork
    {
        IGenericRpository<Flight> Flights { get; }

        IGenericRpository<Ticket> Tickets { get; }

        IGenericRpository<Person> Persons { get; }

        IGenericRpository<Aircraft> Aircrafts { get; }

        IGenericRpository<Port> Ports { get; }

        IGenericRpository<Airline> Airlines { get; }

        IGenericRpository<FlightStatus> FlightStatuses { get; }

        void SaveChanges();

        void Dispose();
    }
}
