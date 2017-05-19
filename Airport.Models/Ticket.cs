using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public enum CabinClass
    {
        Business,
        Economy
    }

    public enum Currency
    {
        UAH,
        RUB,
        USD
    }
    public class Ticket
    {
        [Key]
        public Guid TicketNumberId { get; set; }
        public CabinClass CabinClass { get; set; }
        public string SitNumber { get; set; }
        public decimal Price { get; set; }
        public Currency PriceCurrency { get; set; }

        public virtual Passenger Passenger { get; set; }
        public Guid PassengerPassengerId { get; set; }
    }
}
