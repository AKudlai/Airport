namespace Airport.Models.DomainModels.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Airport.Models.DomainModels.Enums;

    public class Flight
    {
        [Display(Name = "Flight nuber")]
        public string FlightNumber { get; set; }

        public FlightType FlightType { get; set; }

        [Display(Name = "Date")]
        public DateTime FlightDate { get; set; }

        public virtual Port Port { get; set; }

        public Guid PortId { get; set; }

        public string Terminal { get; set; }

        public Gate Gate { get; set; }

        public virtual Aircraft Aircraft { get; set; }

        public Guid AircraftId { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public Guid FlightStatusId { get; set; }

        public virtual FlightStatus FlightStatus { get; set; }
    }
}