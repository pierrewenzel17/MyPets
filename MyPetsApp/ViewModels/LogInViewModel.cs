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

        public void Connection()
        {
            //TextBlock wantedChild = Username as TextBlock;
            //Person person = Task.Run(() => new LoginService().Connection()).GetAwaiter().GetResult();
            //ActualUserSingleton.GetInstance(person);
        }
    }
}
