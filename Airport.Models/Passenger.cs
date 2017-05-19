using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public enum Sex
    {
        Mail,
        Femail
    }
    public class Passenger
    {
        public Guid PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirsday { get; set; }
        public Sex Sex { get; set; }
        public string Nationality { get; set; }
        public string PassportSerial { get; set; }
        public DateTime PassportIssueDate { get; set; }
        public DateTime PassportExpireDate { get; set; }

        public virtual Flight Flight { get; set; }
        public string FlightFlightNumberId { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
