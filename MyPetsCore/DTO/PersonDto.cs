using System;

namespace MyPetsCore.DTO
{
    internal abstract class PersonDto
    {
        protected PersonDto(int? key, string lastName, string forName, string email, string address, uint zipCode, string city, string phoneNumber)
        {
            Key = key;
            LastName = lastName;
            ForName = forName;
            Email = email;
            Address = address;
            ZipCode = zipCode;
            City = city;
            PhoneNumber = phoneNumber;
        }

        public int? Key { get; }
        public string LastName { get; }
        public string ForName { get; }
        public string Email { get; }
        public string Address { get; }
        public uint ZipCode { get; }
        public string City { get; }
        public string PhoneNumber { get; }

        protected bool Equals(PersonDto other)
        {
            return Key == other.Key && LastName == other.LastName && ForName == other.ForName && Email == other.Email && 
                   Address == other.Address && ZipCode == other.ZipCode && City == other.City && PhoneNumber == other.PhoneNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((PersonDto) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Key, LastName, ForName, Email, Address, ZipCode, City, PhoneNumber);
        }

        public static bool operator ==(PersonDto a, PersonDto b)
        {
            return a is not null && a.Equals(b);
        }

        public static bool operator !=(PersonDto a, PersonDto b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return $"{nameof(Key)}: {Key}, {nameof(LastName)}: {LastName}, {nameof(ForName)}: {ForName}, {nameof(Email)}: {Email}, " +
                   $"{nameof(Address)}: {Address}, {nameof(ZipCode)}: {ZipCode}, {nameof(City)}: {City}, {nameof(PhoneNumber)}: {PhoneNumber}";
        }
    }
}
