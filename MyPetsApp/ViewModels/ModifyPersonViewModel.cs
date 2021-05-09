using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPetsApp.Models;
using MyPetsApp.Services;

namespace MyPetsApp.ViewModels
{
    class ModifyPersonViewModel : ViewModelBase
    {
        public ModifyPersonViewModel() {}

        public void ModifyUser(Person person)
        {
            try
            {
                Task.Run(() =>
                    new PersonService().UpdatePerson((int)person.PersonId, person).GetAwaiter().GetResult());
            }
            catch
            {
                throw new InvalidCastException("Cast de PersonId Impossible");
            }
        }
    }
}
