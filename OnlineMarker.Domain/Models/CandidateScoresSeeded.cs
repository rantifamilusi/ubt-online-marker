using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class CandidateScoresSeeded
    {
        public int ScoreId { get; set; }
        public string? Markerid { get; set; }
        public string? Examtype { get; set; }
        public int? Markid { get; set; }
        public string? Papercode { get; set; }
        public string? Indexno { get; set; }
        public bool? Status { get; set; }
        public DateTime? Logdate { get; set; }
        public string? Scriptno { get; set; }
        public string? Seedmaster { get; set; }
        public bool? Seedstatus { get; set; }
        public string? Seededscript { get; set; }
    }
}
