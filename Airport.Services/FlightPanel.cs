//namespace Airport.Services
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    using Airport.Contracts;
//    using Airport.Models.DomainModels.Entities;
//    using Airport.Models.DomainModels.Enums;
//    using Airport.Models.ViewModels;
//    using Airport.Services.Repositories;

//    public class FlightPanel : IFlightPanel
//    {
//        private readonly IUnitOfWork unitOfWork;

//        public FlightPanel()
//        {
//            this.unitOfWork = new UnitOfWork();
//        }

//        public IEnumerable<FlightPanelView> GetFlights()
//        {
//            return
//                this.unitOfWork.Flights.Find(
//                    p => true,
//                    p => p.Port,
//                    p => p.Airline.Aircrafts,
//                    p => p.FlightStatus,
//                    p => p.Tickets)
//                    .Select(
//                    p => new FlightPanelView
//                    {
//                        FlightNumberId = p.FlightNumber,
//                        FlightDate = p.FlightDate,
//                        Port = p.Port.Name,
//                        Airline = p.Airline.Name,
//                        Terminal = p.Terminal,
//                        FlightStatus = p.FlightStatus.Name,
//                        Gate = p.Gate.ToString(),
//                        TicketsCount = p.Tickets.Count()
//                    });
//        }

//        public void AddFlight(FlightPanelView flight)
//        {
//            this.unitOfWork.Flights.Add(new Flight
//            {
//                FlightNumber = flight.FlightNumberId,
//                FlightType = FlightType.Arriving,
//                FlightDate = flight.FlightDate,
//                Port = new Port { Id = Guid.NewGuid(), Name = "Guliany", Country = "Ukrain", LocalityName = "Kiev" },
//                Terminal = flight.Terminal,
//                Gate = Gate.A1,
//                Airline = new Airline { AirlineId = Guid.NewGuid() },
//                FlightStatus = new FlightStatus { Id = Guid.NewGuid(), Name = "check-in" }
//            });
//        }

//        public void EditFlight(FlightPanelView flight)
//        {
//            throw new System.NotImplementedException();
//        }

//        public void DeleteFlight(FlightPanelView flight)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}
