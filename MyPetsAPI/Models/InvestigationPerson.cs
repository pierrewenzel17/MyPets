using System;
using System.Collections.Generic;

#nullable disable

namespace MyPetsAPI.Models
{
    public partial class InvestigationPerson
    {
        public InvestigationPerson()
        {
            InvestigationInvestigationOffenders = new HashSet<Investigation>();
            InvestigationInvestigationPlaintiffs = new HashSet<Investigation>();
        }

        public int? InvestigationPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int Type { get; set; }

        public virtual ICollection<Investigation> InvestigationInvestigationOffenders { get; set; }
        public virtual ICollection<Investigation> InvestigationInvestigationPlaintiffs { get; set; }
    }
}
