namespace Airport.DAL.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Airport.Models.DomainModels.Entities;

    public class PriceMap : EntityTypeConfiguration<Price>
    {
        public PriceMap()
        {
            this.HasKey(p => p.Id);
            this.HasRequired(p => p.Ticket)
                .WithRequiredDependent(p => p.Price);
        }
    }
}
