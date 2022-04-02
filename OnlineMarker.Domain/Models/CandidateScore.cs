using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class CandidateScore
    {
        public int ScoreId { get; set; }
        public string? Examtype { get; set; }
        public int? Markid { get; set; }
        public string? Papercode { get; set; }
        public string? Examinercode { get; set; }
        public string? Indexno { get; set; }
        public int? Quesno { get; set; }
        public decimal? Score { get; set; }
        public int? Numticks { get; set; }
        public int? Status { get; set; }
        public DateTime? Logdate { get; set; }
        public string? Scriptno { get; set; }
        public bool? Mqa { get; set; }
        public decimal? Mecherror { get; set; }
        public int? Wordscount { get; set; }
        public string? Markedpages { get; set; }
        public string? Marksposition { get; set; }
        public bool? Vetted { get; set; }
        public string? Vetterid { get; set; }
        public bool? Reviewed { get; set; }
    }
}
