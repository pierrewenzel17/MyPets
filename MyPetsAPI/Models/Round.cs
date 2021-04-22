using System;
using System.Collections.Generic;

#nullable disable

namespace MyPetsAPI.Models
{
    public partial class Round
    {
        public Round()
        {
            InvestigationToRounds = new HashSet<InvestigationToRound>();
            RoundToInvestigationDocuments = new HashSet<RoundToInvestigationDocument>();
        }

        public int? RoundId { get; set; }
        public DateTime DateRound { get; set; }
        public string CommentRound { get; set; }
        public int InvestigatorId { get; set; }

        public virtual Person Investigator { get; set; }
        public virtual ICollection<InvestigationToRound> InvestigationToRounds { get; set; }
        public virtual ICollection<RoundToInvestigationDocument> RoundToInvestigationDocuments { get; set; }
    }
}
