using Airport.Models;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Airport.Servises;

namespace Airport.DAL
{
    public class FlightsXml
    {
        public static void FillPanelList()
        {
            // Create XML elements from a source file.
            XElement xTree = XElement.Load(@"AppData/PanelDeparture.xml");

            // Create an enumerable collection of the elements.
            IEnumerable<XElement> elements = xTree.Elements();
            // Evaluate each element and set set values in the book object.
            foreach (XElement el in elements)
            {
                Flight flight = new Flight();
                flight.FlightNumber = el.Attribute("flight_number").Value;
                var xAttribute = el.Attribute("flight_number");
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {
                    if (p.Name.ToString().ToLower() == "flight_type")
                    {
                        flight.FType = (FlightType)Enum.Parse(typeof(FlightType), p.Value);
                    }
                    else if (p.Name.ToString().ToLower() == "flight_date")
                    {
                        flight.FlightDate = Convert.ToDateTime(p.Value);
                    }
                    else if (p.Name.ToString().ToLower() == "port")
                    {
                        flight.Port = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "airline")
                    {
                        flight.Airline = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "terminal")
                    {
                        flight.Terminal = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "flight_status")
                    {
                        flight.FlightStatus = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "gate")
                    {
                        flight.Gate = p.Value;
                    }
                }
                Panel.PanelList.Add(flight);
            }
        }
    }
}
