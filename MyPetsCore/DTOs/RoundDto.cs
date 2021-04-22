using System;

namespace MyPetsCore.DTOs
{
    public class RoundDto
    {
        public RoundDto(int? roundId, DateTime dateRound, string commentRound, int investigatorId)
        {
            RoundId = roundId;
            DateRound = dateRound;
            CommentRound = commentRound;
            InvestigatorId = investigatorId;
        }

        public int? RoundId { get; set; }
        public DateTime DateRound { get; set; }
        public string CommentRound { get; set; }
        public int InvestigatorId { get; set; }
    }
}
