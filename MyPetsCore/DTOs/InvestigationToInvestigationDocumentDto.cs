namespace MyPetsCore.DTOs
{
    public class InvestigationToInvestigationDocumentDto
    {
        public InvestigationToInvestigationDocumentDto(int? investigationToInvestigationDocumentId, int investigationId, int investigationDocumentId)
        {
            InvestigationToInvestigationDocumentId = investigationToInvestigationDocumentId;
            InvestigationId = investigationId;
            InvestigationDocumentId = investigationDocumentId;
        }

        #region Attributes

        public int? InvestigationToInvestigationDocumentId { get; set; }
        public int InvestigationId { get; set; }
        public int InvestigationDocumentId { get; set; }

        #endregion
    }
}