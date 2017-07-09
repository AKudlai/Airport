namespace Airport.Models.DomainModels.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Airport.Models.DomainModels.Enums;

    public class Person
    {
        public Guid Id { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Birsday date")]
        public DateTime DateOfBirsday { get; set; }

        public Sex Sex { get; set; }

        public string Nationality { get; set; }

        [Display(Name = "Pasport serial")]
        public string PassportSerial { get; set; }

        [Display(Name = "Passport issue date")]
        public DateTime PassportIssueDate { get; set; }

        [Display(Name = "Passport expire date")]
        public DateTime PassportExpireDate { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
