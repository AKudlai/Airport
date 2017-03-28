using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Airport.Models
{
    public class Panel
    {   
        public static List<Flight> PanelList = new List<Flight>();     
        public static List<Flight> FindFlightNumber (string findString, List<Flight> panelList)
        {
            List<Flight> results = panelList.FindAll(flight => flight.FlightNumber == findString);
            return FlightNotFound(results);
        }

        public static List<Flight> FindFlightDate(DateTime findString, List<Flight> panelList)
        {
            List<Flight> results = panelList.FindAll(flight => flight.FlightDate == findString);
            return FlightNotFound(results);
        }
        public static List<Flight> FindPort(string findString, List<Flight> panelList)
        {
            List<Flight> results = panelList.FindAll(flight => flight.Port == findString);
            return FlightNotFound(results);
        }
        public static List<Flight> FindNearestTime(List<Flight> panelList)
        {
            List<Flight> results = panelList.FindAll(flight => flight.FlightDate >=DateTime.Now & flight.FlightDate <= DateTime.Now.AddHours(1));
            return FlightNotFound(results);
        }
        public static List<Flight> FindFlightType(FlightType flyType)
        {
            List<Flight> results = PanelList.FindAll(flight => flight.FType == flyType);
            PanelList = results;
            return FlightNotFound(results);
        }
        public static void DeleteFlights(string findString, List<Flight> paneList )
        {
            paneList.RemoveAll(flight => flight.FlightNumber == findString);
        }
        private static List<Flight> FlightNotFound(List<Flight> results)
        {
            if (results.Count != 0)
            {
                return results;
            }
            else
            {
                Console.WriteLine("\nFlight not found.");
                return results;
            }
        }
        public static void PrintPanel(List<Flight> panelList)
        {
            // Display header
            var header =
                $"{"Date and time",-20}|{"Flight number",-14}|{"City",-14}|{"Airline",-20}|Terminal|{"Flight status",-14}|{"Gate",-5}|";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(header);
            Console.ResetColor();
            for (int i = 0; i < panelList.Count; i++)
            {
                
                if (i % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine(panelList[i]);
                Console.ResetColor();
            }
        }
        public static void FillPanelList()
        {
            // Create XML elements from a source file.
            XElement xTree = XElement.Load(@"c:\temp\PanelDeparture.xml");

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
                    if (p.Name.ToString().ToLower()== "flight_type")
                    {
                        flight.FType = (FlightType) Enum.Parse(typeof(FlightType), p.Value);
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
                PanelList.Add(flight);
            }
        }
    }
}
