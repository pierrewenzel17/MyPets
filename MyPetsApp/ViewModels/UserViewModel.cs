using MyPetsApp.Models;
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
    }
}