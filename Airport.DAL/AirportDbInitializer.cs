using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Models;

namespace Airport.DAL
{
    public class AirportDbInitializer: DropCreateDatabaseAlways<AirportContext>
    {
        protected override void Seed(AirportContext context)
        {
            context.Flights.Add(new Flight
            {
                FlightNumberId = "AK 1234",
                FlightType = FlightType.Arriving,
                FlightDate = DateTime.Parse("2017-06-05"),
                Airline = "MAU",
                FlightStatus = "canseled",
                Gate = "D1",
                Port = "Dnipro",
                Terminal = "D"
            });
            context.Flights.Add(new Flight
            {
                FlightNumberId = "SD 5349",
                FlightType = FlightType.Arriving,
                FlightDate = DateTime.Parse("2017-06-01"),
                Airline = "MAU",
                FlightStatus = "canseled",
                Gate = "D1",
                Port = "Kiev",
                Terminal = "D"
            });
            context.Flights.Add(new Flight
            {
                FlightNumberId = "MS 45430",
                FlightType = FlightType.Arriving,
                FlightDate = DateTime.Parse("2017-06-01"),
                Airline = "MAU",
                FlightStatus = "canseled",
                Gate = "D1",
                Port = "Kiev",
                Terminal = "D"
            });
            base.Seed(context);
        }
    }
}
