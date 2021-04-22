using System;
using System.Collections.Generic;

#nullable disable

namespace MyPetsAPI.Models
{
    public partial class InvestigationToRound
    {
        public int? InvestigationToRoundId { get; set; }
        public int RoundId { get; set; }
        public int InvestigationId { get; set; }

        public virtual Investigation Investigation { get; set; }
        public virtual Round Round { get; set; }
    }
}
