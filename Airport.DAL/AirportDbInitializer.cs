﻿namespace Airport.DAL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Airport.Models.DomainModels.Entities;
    using Airport.Models.DomainModels.Enums;

    public class AirportDbInitializer : DropCreateDatabaseAlways<AirportContext>
    {
        protected override void Seed(AirportContext context)
        {
            context.Flights.Add(
                new Flight
                    {
                        FlightNumber = "FG 123",
                        FlightDate = DateTime.Today,
                        FlightStatus = new FlightStatus { Id = Guid.NewGuid(), Name = "check-in" },
                        Airline =
                            new Airline
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "MAU",
                                    Aircrafts =
                                        new List<Aircraft>
                                            {
                                                new Aircraft
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        BusinessClassSitCount = 5,
                                                        EconomyClassSitCount = 20,
                                                        FirstClassSitCount = 3,
                                                        Model = "AD"
                                                    }
                                            }
                                },
                        Port =
                            new Port
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Guliany",
                                    Country = "Ukrain",
                                    LocalityName = "Kiev"
                                },
                        FlightType = FlightType.Departure,
                        Gate = Gate.A2,
                        Terminal = "A",
                        Tickets =
                            new List<Ticket>
                                {
                                    new Ticket
                                        {
                                            TicketNumber = Guid.NewGuid(),
                                            Person =
                                                new Person
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        FirstName = "Alex",
                                                        LastName = "Kudlai",
                                                        DateOfBirsday = DateTime.Today,
                                                        PassportExpireDate =
                                                            DateTime.Today,
                                                        PassportSerial = "AK 12324",
                                                        PassportIssueDate =
                                                            DateTime.Today,
                                                        Sex = Sex.Mail,
                                                        Nationality = "Ukrainian"
                                                    },
                                            CabinClass = CabinClass.Business,
                                            SitNumber = "C1",
                                        }
                                    
                                }

                    });           
            base.Seed(context);
        }
    }
}
