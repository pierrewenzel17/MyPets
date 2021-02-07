#nullable enable
using System.ComponentModel.DataAnnotations;

namespace MyPetsCore.DTO
{
    class VolunteerDto : PersonDto
    {
        public VolunteerDto(int? key, string lastName, string forName, string email, string address, uint zipCode, string city, string phoneNumber, string password) : 
            base(key, lastName, forName, email, address, zipCode, city, phoneNumber)
        {
            Password = password;
        }

        public string Password { get; }
    }
}