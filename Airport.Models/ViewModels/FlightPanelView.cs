namespace Airport.Models.ViewModels
{
    using System;

    public class FlightPanelView
    {
        public string FlightNumberId { get; set; }

        public DateTime FlightDate { get; set; }

        public string Port { get; set; }

        public string Airline { get; set; }

        public string Terminal { get; set; }

        public string FlightStatus { get; set; }

        public string Gate { get; set; }

        public string Tickets { get; set; }
    }
}
