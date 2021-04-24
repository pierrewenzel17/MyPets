using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPetsCore.DTOs;

namespace MyPetsWeb.ModelViews
{
    public class PersonMapper
    {
        public PersonDto ToDto(PersonView personView)
        {
            return new(personView.PersonId, personView.FirstName, personView.LastName, personView.Email,
                personView.Address, personView.ZipCode, personView.City, personView.PhoneNumber, personView.Hierarchy,
                personView.Zone, personView.Password);
        }

        public PersonView ToView(PersonDto dto)
        {
            if (dto.PersonId != null)
                return new()
                {
                    PersonId = (int) dto.PersonId,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Address = dto.Address,
                    ZipCode = dto.ZipCode,
                    City = dto.City,
                    PhoneNumber = dto.PhoneNumber,
                    Hierarchy = dto.Hierarchy,
                    Zone = dto.Zone,
                    Password = dto.Password
                };
            return null;
        }
    }
}
