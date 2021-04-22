namespace MyPetsCore.DTOs
{
    public class RoundToInvestigationDocumentDto
    {
        public RoundToInvestigationDocumentDto(int? roundToInvestigationDocumentId, int roundId, int investigationDocumentId)
        {
            RoundToInvestigationDocumentId = roundToInvestigationDocumentId;
            RoundId = roundId;
            InvestigationDocumentId = investigationDocumentId;
        }

        #region Attributes

        public int? RoundToInvestigationDocumentId { get; set; }
        public int RoundId { get; set; }
        public int InvestigationDocumentId { get; set; }

        #endregion
    }
}