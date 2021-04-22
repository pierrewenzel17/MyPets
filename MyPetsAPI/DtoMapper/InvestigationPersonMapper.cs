using MyPetsAPI.Models;
using MyPetsCore.DTOs;

namespace MyPetsAPI.DtoMapper
{
    public class InvestigationPersonMapper : IDtoMapper<InvestigationPersonDto, InvestigationPerson>
    {
        public InvestigationPersonMapper()
        {
            
        }

        public InvestigationPersonDto ToDto(InvestigationPerson model)
        {
            return new InvestigationPersonDto(
                model.InvestigationPersonId,
                model.FirstName,
                model.LastName,
                model.Email,
                model.Address,
                model.ZipCode,
                model.City,
                model.PhoneNumber,
                model.Type
            );
        }

        public InvestigationPerson ToModel(InvestigationPersonDto dto)
        {
            return new InvestigationPerson()
            {
                InvestigationPersonId = dto.InvestigationPersonId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Address = dto.Address,
                ZipCode = dto.ZipCode,
                City = dto.City,
                PhoneNumber = dto.PhoneNumber,
                Type = dto.Type
            };
        }
    }
}