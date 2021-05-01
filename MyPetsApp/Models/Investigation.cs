using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPetsApp.Models
{
    public class Investigation
    {
        #region Attributes
        public int? InvestigationId { get; set; }
        public Person HolderInvestigatorId { get; set; }
        public InvestigationPerson InvestigationOffenderId { get; set; }
        public InvestigationPerson InvestigationPlaintiffId { get; set; }
        public string Reason { get; set; }
        public string Breed { get; set; }
        public int NumberOfPets { get; set; }

        public string IsFinish { get; private set; }

        public void Set(bool b)
        {
            IsFinish = b ? "Cloturé" : "En Cours";
        }

        #endregion
    }
}
