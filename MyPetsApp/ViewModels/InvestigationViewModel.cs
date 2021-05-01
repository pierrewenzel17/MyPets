using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPetsApp.Models;
using MyPetsApp.Services;



namespace MyPetsApp.ViewModels
{
    public class InvestigationViewModel : ViewModelBase
    {
        public InvestigationViewModel()
        {
            Investigations = Task.Run(() => new InvestigationService().Get()).GetAwaiter().GetResult();
        }
        public IEnumerable<Investigation> Investigations { get; set; }
    }
}
