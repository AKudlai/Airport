using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airport.Models
{
    public enum FlightType
    {
        Arriving,
        Departure
    }

    public partial class Flight
    {
        [Key]
        public string FlightNumberId { get; set; }
        public FlightType FlightType { get; set; }
        public DateTime FlightDate { get; set; }
        public string Port { get; set; }
        public string Airline { get; set; }
        public string Terminal { get; set; }
        public string FlightStatus { get; set; }
        public string Gate { get; set; }

        public virtual ICollection<Passenger> Pessengers { get; set; }
    }
}