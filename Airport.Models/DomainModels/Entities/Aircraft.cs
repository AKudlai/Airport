namespace Airport.Models.DomainModels.Entities
{
    using System;

    public class Aircraft
    {
        public Guid AircraftId { get; set; }

        public string Model { get; set; }

        //public byte[] Photo { get; set; }

        //public byte[] SitsPlan { get; set; }

        public int FirstClassSit { get; set; }

        public int BusinessClassSit { get; set; }

        public int EconomyClassSit { get; set; }

        public Guid AirlineId { get; set; }

        public virtual Airline Airline { get; set; }

    }
}
