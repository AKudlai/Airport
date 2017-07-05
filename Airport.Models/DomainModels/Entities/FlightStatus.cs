namespace Airport.Models.DomainModels.Entities
{
    using System;
    using System.Collections.Generic;

    public class FlightStatus
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
