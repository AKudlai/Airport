namespace Airport.Models.DomainModels.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Airline
    {
        public Guid Id { get; set; }

        [Display(Name = "Airline")]
        public string Name { get; set; }

        public byte[] Logo { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public virtual ICollection<Aircraft> Aircrafts { get; set; }
    }
}
