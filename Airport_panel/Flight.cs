using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public enum FlightType
    {
        Arriving,
        Departure
    }
    public class Flight
    {
        #region Declarations
        public FlightType FType { get; set; }
        public DateTime FlightDate { get; set; }
        public string FlightNumber { get; set; }
        public string Port { get; set; }
        public string Airline { get; set; }
        public string Terminal { get; set; }
        public string FlightStatus { get; set; }
        public string Gate { get; set; }
        #endregion
        #region Constructors
        public Flight(FlightType fType, DateTime flightDate, string flightNumber, 
            string port, string airline, string terminal, string flightStatus, string gate)
        {
            FType = fType;
            FlightDate = flightDate;
            FlightNumber = flightNumber;
            Port = port;
            Airline = airline;
            Terminal = terminal;
            FlightStatus = flightStatus;
            Gate = gate;
        }
        public Flight()
        {
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            var formatedString =
                $"{FlightDate,-20}|{FlightNumber.PadRight(14, ' ')}|{Port.PadRight(14, ' ')}|" +
                $"{Airline.PadRight(20, ' ')}|{Terminal.PadRight(8, ' ')}|{FlightStatus.PadRight(14, ' ')}|" +
                $"{Gate.PadRight(5, ' ')}|";
            return formatedString;
        }
        #endregion
    }
}