using System;
using System.Collections.Generic;

#nullable disable

namespace MyPetsAPI.Models
{
    public partial class InvestigationDocument
    {
        public InvestigationDocument()
        {
            InvestigationToInvestigationDocuments = new HashSet<InvestigationToInvestigationDocument>();
            RoundToInvestigationDocuments = new HashSet<RoundToInvestigationDocument>();
        }

        public int? InvestigationDocumentId { get; set; }
        public byte[] File { get; set; }

        public virtual ICollection<InvestigationToInvestigationDocument> InvestigationToInvestigationDocuments { get; set; }
        public virtual ICollection<RoundToInvestigationDocument> RoundToInvestigationDocuments { get; set; }
    }
}
