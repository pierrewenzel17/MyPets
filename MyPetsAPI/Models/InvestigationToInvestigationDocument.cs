using System;
using System.Collections.Generic;

#nullable disable

namespace MyPetsAPI.Models
{
    public partial class InvestigationToInvestigationDocument
    {
        public int? InvestigationToInvestigationDocumentId { get; set; }
        public int InvestigationId { get; set; }
        public int InvestigationDocumentId { get; set; }

        public virtual Investigation Investigation { get; set; }
        public virtual InvestigationDocument InvestigationDocument { get; set; }
    }
}
