namespace Airport.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Airport.Models.DomainModels.Entities;

    public class FlightPanelView
    {
        public IEnumerable<Flight> Flights { get; set; }

        public string Search { get; set; }

        public IEnumerable<FlyghtTypeWithCount> FlyghtsTypeWithCount { get; set; }

        public string FlyghtType { get; set; }

        public IEnumerable<SelectListItem> FlyghtFilterItems
        {
            get
            {
                var allFlyghtTypes =
                    this.FlyghtsTypeWithCount.Select(
                        cc => new SelectListItem { Value = cc.FlyghtTypeName, Text = cc.FlyghtTypeNameWithCount });
                return allFlyghtTypes;
            }
        }

        public class FlyghtTypeWithCount
        {
            public int FlightCount { get; set; }

            public string FlyghtTypeName { get; set; }

            public string FlyghtTypeNameWithCount => this.FlyghtTypeName + " (" + this.FlightCount.ToString() + ")";
        }
    }
}
