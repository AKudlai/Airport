namespace Airport.Models.DomainModels.Entities
{
    using System;

    public class Price
    {
        public Guid Id { get; set; }

        public Ticket Ticket { get; set; }

        public decimal Value { get; set; }
    }
}
