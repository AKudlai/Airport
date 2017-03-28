using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Servises;
using Airport.Models;

namespace Airport.View
{
    public class ConsoleInput
    {
        //Main menu
        public static void MenuMain()
        {
            Console.WriteLine("Print arrival panel — 1");
            Console.WriteLine("Print departure panel — 2");
            Console.WriteLine("Add new flight — 3");
            Console.WriteLine("Remove flight — 4");
            Console.WriteLine("Find flight — 5");
            Console.WriteLine("Edit arrival panel — 6");
            Console.WriteLine("Edit arrival panel — 7");
            Console.Write("Your chose? ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("\nInformation about arrivals:");
                    Panel.PrintPanel(Panel.FindFlightType(FlightType.Arriving));
                    Console.WriteLine();
                    break;
                case "2":
                    Panel.PrintPanel(Panel.PanelList);
                    Console.WriteLine("\nInformation about departures:");
                    Panel.PrintPanel(Panel.FindFlightType(FlightType.Departure));
                    Console.WriteLine();
                    Panel.PrintPanel(Panel.PanelList);
                    break;
                case "3":
                    AddFlight();
                    break;
                case "4":
                    DeleteFlight();
                    break;
                case "5":
                    MenuFind();
                    break;
                case "6":
                    break;
                case "7":
                    break;
                default:
                    Console.WriteLine("Please, choose one!\n");
                    MenuMain();
                    break;
            }
        }
        //Menu enter flight status
        public static string MenuFlightStatus()
        {
            Console.WriteLine("\nEnter flight status: ");
            Console.WriteLine("check-in — 1");
            Console.WriteLine("gate closed — 2");
            Console.WriteLine("arrived — 3");
            Console.WriteLine("departed at — 4");
            Console.WriteLine("unknown — 5");
            Console.WriteLine("canceled — 6");
            Console.WriteLine("delayed — 7");
            Console.WriteLine("in flight — 8");
            Console.Write("Your chose? ");
            string flStat = "unknown";
            switch (Console.ReadLine())
            {
                case "1":
                    flStat = "check-in";
                    break;
                case "2":
                    flStat = "gate closed";
                    break;
                case "3":
                    flStat = "arrived";
                    break;
                case "4":
                    flStat = "departed at";
                    break;
                case "5":
                    flStat = "unknown";
                    break;
                case "6":
                    flStat = "canceled";
                    break;
                case "7":
                    flStat = "delayed";
                    break;
                case "8":
                    flStat = "in flight";
                    break;
                default:
                    Console.WriteLine("Please, choose one!\n");
                    MenuFlightStatus();
                    break;
            }
            return flStat;
        }
        //Menu flight type
        public static FlightType MenuFlightType()
        {
            Console.WriteLine("\nEnter flight panel\nArriving (defoult) — 1\nDeparture — 2");
            switch (Console.ReadLine())
            {
                case "1":
                    return FlightType.Arriving;
                case "2":
                    return FlightType.Departure;
                default:
                    return FlightType.Arriving;
            }
        }
        //Menu find
        public static void MenuFind()
        {
            FlightType fType = MenuFlightType();
            Console.WriteLine("\nFind flight which is the nearest 1 hour (sorted by time) — 1");
            Console.WriteLine("Find flight by flight number — 2");
            Console.WriteLine("Find flight by port — 3 ");
            Console.Write("Your chose? ");
            switch (Console.ReadLine())
            {
                case "1":
                    var result1 = Panel.FindNearestTime(Panel.FindFlightType(fType));
                    Panel.PrintPanel(result1);
                    break;
                case "2":
                    Console.Write("Enter fligt number: ");
                    var result2 = Panel.FindFlightNumber(Console.ReadLine(), Panel.FindFlightType(fType));
                    Panel.PrintPanel(result2);
                    break;
                case "3":
                    Console.Write("Enter port: ");
                    var result3 = Panel.FindPort(Console.ReadLine(), Panel.FindFlightType(fType));
                    Panel.PrintPanel(result3);
                    Panel.PrintPanel(Panel.PanelList);
                    break;
                default:
                    Console.WriteLine("Please, choose one!\n");
                    MenuFlightStatus();
                    break;
            }
        }
        //Menu add fight
        public static void AddFlight()
        {
            FlightType fType = MenuFlightType();
            Console.Write("\nEnter date and time: ");
            string dateString = Console.ReadLine();
            DateTime flightDate = ParseDate(dateString);
            Console.Write("Enter flight number: ");
            string flightNumber = Console.ReadLine();
            Console.Write("Enter port: ");
            string port = Console.ReadLine();
            Console.Write("Enter airline: ");
            string airline = Console.ReadLine();
            Console.Write("Enter terminal: ");
            string terminal = Console.ReadLine();
            Console.Write("Enter flight status: ");
            string flightStatus = MenuFlightStatus();
            Console.Write("Enter gate: ");
            string gate = Console.ReadLine();
            Flight flight = new Flight(fType, flightDate, flightNumber,
                port, airline, terminal, flightStatus, gate);
            Panel.PanelList.Add(flight);
            Console.WriteLine();
        }
        //Menu Menu delete fight
        public static void DeleteFlight()
        {
            FlightType fType = MenuFlightType();
            Console.Write("\nEnter flight number: ");
            Panel.DeleteFlights(Console.ReadLine(), Panel.FindFlightType(fType));
        }
        //Data parser
        public static DateTime ParseDate(string dateString)
        {
            bool ctrl;
            DateTime parsedDate;
            do
            {
                ctrl = DateTime.TryParse(dateString, out parsedDate);
                if (!ctrl)
                {
                    Console.WriteLine("\nBad format");
                }
            }
            while (ctrl == false);
            return parsedDate;
        }
    }
}
