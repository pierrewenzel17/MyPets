using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPetsApp.Models;
using MyPetsApp.Services;

namespace MyPetsApp.ViewModels
{
    class NewPersonViewModel : ViewModelBase
    {
        public NewPersonViewModel()
        {

        }

        

        public void CreateUser(Person person)
        {
            Task.Run(() => new PersonService().CreatePerson(person).GetAwaiter().GetResult());
        }
    }
}
