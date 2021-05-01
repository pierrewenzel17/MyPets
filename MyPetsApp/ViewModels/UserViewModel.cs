using System.Threading.Tasks;
using MyPetsApp.Models;
using MyPetsApp.Services;

namespace MyPetsApp.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public UserViewModel()
        {
            // ActualUser = Task.Run(() => new PersonService().GetPerson(0)).GetAwaiter().GetResult();
        }
        public Person ActualUser { get; set; }
    }
}