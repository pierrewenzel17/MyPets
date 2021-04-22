namespace MyPetsCore.DTOs
{
    public class InvestigationPersonDto
    {
        public InvestigationPersonDto(int? investigationPersonId, string firstName, string lastName, string email, string address, string zipCode, string city, string phoneNumber, int type)
        {
            InvestigationPersonId = investigationPersonId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            ZipCode = zipCode;
            City = city;
            PhoneNumber = phoneNumber;
            Type = type;
        }

        #region Attributes
        public int? InvestigationPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int Type { get; set; }
        #endregion
    }
}