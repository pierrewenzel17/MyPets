using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPetsCore.DTO
{
    class AdminDto : EmployeeDto
    {
        public AdminDto(int? key, string lastName, string forName, string email, string address, uint zipCode, string city, string phoneNumber) : 
            base(key, lastName, forName, email, address, zipCode, city, phoneNumber)
        {
        }
    }
}
