using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class SeededScriptsScore
    {
        public int ScoreId { get; set; }
        public string? Examtype { get; set; }
        public string? Papercode { get; set; }
        public int? Markid { get; set; }
        public string? Markerid { get; set; }
        public string? Indexno { get; set; }
        public int? Quesno { get; set; }
        public decimal? Score { get; set; }
        public int? Numticks { get; set; }
        public bool? Status { get; set; }
        public DateTime? Logdate { get; set; }
        public string? Scriptno { get; set; }
        public bool? Mqa { get; set; }
        public decimal? Mecherror { get; set; }
        public int? Wordscount { get; set; }
        public string? Seedmaster { get; set; }
        public string? Markedpages { get; set; }
        public bool? Seedstatus { get; set; }
        public string? Marksposition { get; set; }
    }
}
