#nullable enable
using System.ComponentModel.DataAnnotations;

namespace MyPetsCore.DTO
{
    public class VolunteerDto : PersonDto
    {
        public VolunteerDto():base() { }

        public VolunteerDto(int? key, string lastName, string forName, string email, string address, uint zipCode, string city, string phoneNumber, string password) : 
            base(key, lastName, forName, email, address, zipCode, city, phoneNumber)
        {
            Password = password;
        }

        public string Password { get; }
    }
}