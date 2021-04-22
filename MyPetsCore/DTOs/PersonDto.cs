namespace MyPetsCore.DTOs
{
    public class PersonDto
    {
        public PersonDto(int? personId, string firstName, string lastName, string email, string address, string zipCode, string city, string phoneNumber, int hierarchy, string zone, string password)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            ZipCode = zipCode;
            City = city;
            PhoneNumber = phoneNumber;
            Hierarchy = hierarchy;
            Zone = zone;
            Password = password;
        }

        #region Attributes
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
        #endregion
    }
}
