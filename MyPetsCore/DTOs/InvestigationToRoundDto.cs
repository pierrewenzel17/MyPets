namespace MyPetsCore.DTOs
{
    public class InvestigationToRoundDto
    {
        public InvestigationToRoundDto(int? investigationToRoundId, int roundId, int investigationId)
        {
            InvestigationToRoundId = investigationToRoundId;
            RoundId = roundId;
            InvestigationId = investigationId;
        }

        #region Attributes

        public int? InvestigationToRoundId { get; set; }
        public int RoundId { get; set; }
        public int InvestigationId { get; set; }

        #endregion
    }
}