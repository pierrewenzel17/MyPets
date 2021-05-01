using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPetsApp.Models;

namespace MyPetsApp.Utils
{
    class ActualUserSingleton
    {
        private ActualUserSingleton(Person person)
        {

        }

        private static ActualUserSingleton _instance;
        public static ActualUserSingleton GetInstance(Person person = null)
        {
            if (_instance == null)
            {
                _instance = new ActualUserSingleton(person);
            }
            return _instance;
        }
    }
}
