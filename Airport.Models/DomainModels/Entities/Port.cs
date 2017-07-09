namespace Airport.Models.DomainModels.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Airport.Models.DomainModels.Entities;

    public class Port
    {
        public Guid Id { get; set; }

        [Display(Name = "Port")]
        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public string Country { get; set; }

        [Display(Name = "LocalityName")]
        public string LocalityName { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}