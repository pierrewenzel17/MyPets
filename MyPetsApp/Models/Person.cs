using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPetsCore.DTOs;

namespace MyPetsApp.Models
{
    public class Person
    {
        #region Attributes
        public int? PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public String Hierarchy { get; set; }
        public string Zone { get; set; }
        public string Password { get; set; }

        public void Set(int key)
        {
            switch (key)
            {
                case 1: Hierarchy = "Bénévole"; break;
                case 2: Hierarchy = "Salarié"; break;
                case 3: Hierarchy = "Administrateur"; break;
            }
        }

        #endregion
    }
}
