using MyPetsAPI.Models;
using MyPetsCore.DTOs;

namespace MyPetsAPI.DtoMapper
{
    public class PersonMapper : IDtoMapper<PersonDto, Person>
    {
        public PersonDto ToDto(Person model)
        {
            return new(
                model.PersonId,
                model.FirstName,
                model.LastName,
                model.Email,
                model.Address,
                model.ZipCode,
                model.City,
                model.PhoneNumber,
                model.Hierarchy,
                model.Zone,
                model.Password
            );
        }

        public Person ToModel(PersonDto dto)
        {
            return new()
            {
                PersonId = dto.PersonId,
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
        }
    }
}
