using System;
using System.Collections.Generic;
using System.Linq;
using Airport.Models;

namespace Airport.Servises
{
    public class Panel
    {   
        public static List<Flight> PanelList = new List<Flight>();     
        public static List<Flight> FindFlightNumber (string findString, List<Flight> panelList)
        {
            List<Flight> results = panelList.FindAll(flight => flight.FlightNumberId == findString);
            panelList.AsQueryable().Where(e => e.Airline == "s");
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
            List<Flight> results = PanelList.FindAll(flight => flight.FlightType == flyType);
            PanelList = results;
            return FlightNotFound(results);
        }
        public static void DeleteFlights(string findString, List<Flight> paneList )
        {
            paneList.RemoveAll(flight => flight.FlightNumberId == findString);
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
       
    }
}
