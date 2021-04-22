using System;
using System.Collections.Generic;

#nullable disable

namespace MyPetsAPI.Models
{
    public partial class Person
    {
        public Person()
        {
            Investigations = new HashSet<Investigation>();
            Rounds = new HashSet<Round>();
        }

        public int? PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int Hierarchy { get; set; }
        public string Zone { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Investigation> Investigations { get; set; }
        public virtual ICollection<Round> Rounds { get; set; }
    }
}
