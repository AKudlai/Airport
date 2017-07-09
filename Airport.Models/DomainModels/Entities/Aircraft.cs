namespace Airport.Models.DomainModels.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Aircraft
    {
        public Guid Id { get; set; }

        public string Model { get; set; }

        public byte[] Photo { get; set; }

        [Display(Name = "Sits plan")]
        public byte[] SitsPlan { get; set; }

        [Display(Name = "First class sits")]
        public int FirstClassSitCount { get; set; }

        [Display(Name = "Business class sits")]
        public int BusinessClassSitCount { get; set; }

        [Display(Name = "Economy class sits")]
        public int EconomyClassSitCount { get; set; }

        public Guid AirlineId { get; set; }

        public virtual Airline Airline { get; set; }

    }
}
