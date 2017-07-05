namespace Airport.Models.DomainModels.Entities
{
    using System;
    using System.Collections.Generic;

    public class Airline
    {
        public Guid AirlineId { get; set; }

        public string Name { get; set; }

        //public byte[] Logo { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public virtual ICollection<Aircraft> Aircrafts { get; set; }
    }
}
