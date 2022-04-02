using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class ErraticMarkingAudit
    {
        public int AuditId { get; set; }
        public string? Examtype { get; set; }
        public string? Papercode { get; set; }
        public string? Examinercode { get; set; }
        public string? Indexnumber { get; set; }
        public int? Quesno { get; set; }
        public decimal? Score { get; set; }
        public DateTime? Logdate { get; set; }
        public string? Scriptno { get; set; }
        public bool? Seeded { get; set; }
        public bool? Vetted { get; set; }
        public string? Blockedno { get; set; }
        public DateTime? Blockeddate { get; set; }
    }
}
