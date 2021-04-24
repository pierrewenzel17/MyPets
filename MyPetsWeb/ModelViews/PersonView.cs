using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPetsWeb.ModelViews
{
    public class PersonView
    {

        #region Attributes
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public int Hierarchy { get; set; }
        [Required]
        public string Zone { get; set; }
        [Required, PasswordPropertyText]
        public string Password { get; set; }
        #endregion
    }
}
