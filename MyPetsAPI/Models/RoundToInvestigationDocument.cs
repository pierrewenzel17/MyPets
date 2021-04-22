using System;
using System.Collections.Generic;

#nullable disable

namespace MyPetsAPI.Models
{
    public partial class RoundToInvestigationDocument
    {
        public int? RoundToInvestigationDocumentId { get; set; }
        public int RoundId { get; set; }
        public int InvestigationDocumentId { get; set; }

        public virtual InvestigationDocument InvestigationDocument { get; set; }
        public virtual Round Round { get; set; }
    }
}
