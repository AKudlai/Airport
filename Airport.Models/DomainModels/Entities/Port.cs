namespace Airport.Models.DomainModels.Entities
{
    using System;
    using System.Collections.Generic;

    using Airport.Models.DomainModels.Entities;

    public class Port
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        // public byte[] Photo { get; set; }

        public string Country { get; set; }

        public string LocalityName { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}