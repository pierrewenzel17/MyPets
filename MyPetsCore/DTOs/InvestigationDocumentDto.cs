namespace MyPetsCore.DTOs
{
    public class InvestigationDocumentDto
    {
        public InvestigationDocumentDto(int? investigationDocumentId, byte[] file)
        {
            InvestigationDocumentId = investigationDocumentId;
            File = file;
        }

        public int? InvestigationDocumentId { get; set; }
        public byte[] File { get; set; }
    }
}