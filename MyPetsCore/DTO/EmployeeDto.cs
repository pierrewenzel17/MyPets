namespace MyPetsCore.DTO
{
    public class EmployeeDto : PersonDto
    {
        public EmployeeDto() : base() { }
        public EmployeeDto(int? key, string lastName, string forName, string email, string address, uint zipCode, string city, string phoneNumber) : 
            base(key, lastName, forName, email, address, zipCode, city, phoneNumber)
        {
        }
    }
}