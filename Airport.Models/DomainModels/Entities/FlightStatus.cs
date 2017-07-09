namespace Airport.Models.DomainModels.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class FlightStatus
    {
        public Guid Id { get; set; }

        [Display(Name = "Flight status")]
        public string Name { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
