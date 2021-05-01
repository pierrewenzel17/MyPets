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

        private static Person _instance;

        public static Person GetInstance(Person person = null)
        {
            if (_instance == null)
            {
                _instance = person;
            }
            return _instance;
        }
    }
}
