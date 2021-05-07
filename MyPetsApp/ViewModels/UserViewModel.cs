using System;
using System.Threading.Tasks;
using MyPetsApp.Models;
using MyPetsApp.Services;
using MyPetsApp.Utils;

namespace MyPetsApp.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public UserViewModel()
        {
            ActualUser = ActualUserSingleton.GetInstance();
        }

        public Person ActualUser { get; init; }

        public void ModifyUser(Person person)
        {
            try
            {
                Task.Run(() =>
                    new PersonService().UpdatePerson((int) person.PersonId, person).GetAwaiter().GetResult());
            }
            catch
            {
                throw new InvalidCastException("Cast de PersonId Impossible");
            }
        }
    }
}