namespace Airport.Models.DomainModels.Entities
{
    using System;
    using System.Collections.Generic;

    using Airport.Models.DomainModels.Enums;

    public class Ticket
    {
        public Guid TicketNumber { get; set; }

        public CabinClass CabinClass { get; set; }

        public string SitNumber { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public virtual Person Person { get; set; }

        public Guid? PersonId { get; set; }

        public virtual Price Price { get; set; }
    }
}
