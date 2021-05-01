using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MyPetsApp.Models;
using MyPetsApp.Services;
using MyPetsApp.Utils;

namespace MyPetsApp.ViewModels
{
    class LogInViewModel : ViewModelBase
    {
        public LogInViewModel()
        {
            
        }

        public void Connection(string email, string password)
        {
            //Person person = Task.Run(() => new LoginService().Connection(email, password)).GetAwaiter().GetResult();
            //ActualUserSingleton.GetInstance(person);
        }
    }
}
