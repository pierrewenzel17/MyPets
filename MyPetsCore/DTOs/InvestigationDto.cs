namespace MyPetsCore.DTOs
{
    public class InvestigationDto
    {
        public InvestigationDto(int? investigationId, int holderInvestigatorId, int investigationOffenderId, int investigationPlaintiffId, string reason, string breed, int numberOfPets, bool isFinish)
        {
            InvestigationId = investigationId;
            HolderInvestigatorId = holderInvestigatorId;
            InvestigationOffenderId = investigationOffenderId;
            InvestigationPlaintiffId = investigationPlaintiffId;
            Reason = reason;
            Breed = breed;
            NumberOfPets = numberOfPets;
            IsFinish = isFinish;
        }

        #region Attributes
        public int? InvestigationId { get; set; }
        public int HolderInvestigatorId { get; set; }
        public int InvestigationOffenderId { get; set; }
        public int InvestigationPlaintiffId { get; set; }
        public string Reason { get; set; }
        public string Breed { get; set; }
        public int NumberOfPets { get; set; }
        public bool IsFinish { get; set; }
        #endregion
    }
}
