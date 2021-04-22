using System;
using System.Collections.Generic;

#nullable disable

namespace MyPetsAPI.Models
{
    public partial class Investigation
    {
        public Investigation()
        {
            InvestigationToInvestigationDocuments = new HashSet<InvestigationToInvestigationDocument>();
            InvestigationToRounds = new HashSet<InvestigationToRound>();
        }

        public int? InvestigationId { get; set; }
        public int HolderInvestigatorId { get; set; }
        public int InvestigationOffenderId { get; set; }
        public int InvestigationPlaintiffId { get; set; }
        public string Reason { get; set; }
        public string Breed { get; set; }
        public int NumberOfPets { get; set; }
        public bool IsFinish { get; set; }

        public virtual Person HolderInvestigator { get; set; }
        public virtual InvestigationPerson InvestigationOffender { get; set; }
        public virtual InvestigationPerson InvestigationPlaintiff { get; set; }
        public virtual ICollection<InvestigationToInvestigationDocument> InvestigationToInvestigationDocuments { get; set; }
        public virtual ICollection<InvestigationToRound> InvestigationToRounds { get; set; }
    }
}
