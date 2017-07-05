namespace Airport.DAL.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Airport.Models.DomainModels.Entities;

    public class PersonMap: EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            this.HasMany(p => p.Tickets)
                .WithOptional(p => p.Person)
                .HasForeignKey(p => p.TicketNumber);
        }
    }
}