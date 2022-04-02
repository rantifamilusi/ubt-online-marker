using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class CandScoresSeededAudit
    {
        public int ScoreId { get; set; }
        public string? Markerid { get; set; }
        public string? Examtype { get; set; }
        public int? Markid { get; set; }
        public string? Papercode { get; set; }
        public int? Quesno { get; set; }
        public decimal? Score { get; set; }
        public DateTime? Logdate { get; set; }
        public string? Seedmaster { get; set; }
        public bool? Seedstatus { get; set; }
        public string? Userlogin { get; set; }
        public string? Marksposition { get; set; }
    }
}
