namespace Airport.Models.DomainModels.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Airport.Models.DomainModels.Enums;

    public class Ticket
    {
        [Display(Name = "Ticket number")]
        public Guid TicketNumber { get; set; }

        [Display(Name = "Cabin class")]
        public CabinClass CabinClass { get; set; }

        [Display(Name = "Sit Number")]
        public string SitNumber { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public virtual Person Person { get; set; }

        public Guid? PersonId { get; set; }

        public decimal Price  { get; set; }
    }
}
