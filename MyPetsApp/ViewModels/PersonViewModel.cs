using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPetsApp.Models;
using MyPetsApp.Services;

namespace MyPetsApp.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        public PersonViewModel()
        {
            //Persons = Task.Run(() => new PersonService().Get()).GetAwaiter().GetResult();
        }
        public IEnumerable<Person> Persons { get; set; }
    }
}
