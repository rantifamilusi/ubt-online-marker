using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class CandidateMarksDatum
    {
        public int MarkId { get; set; }
        public string? Examtype { get; set; }
        public string? Centreno { get; set; }
        public string? Schno { get; set; }
        public string? Indexnumber { get; set; }
        public string? Candname { get; set; }
        public string? Papercode { get; set; }
        public string? Mark { get; set; }
        public string? Examinercode { get; set; }
        public DateTime? Entrydate { get; set; }
        public string? LoginId { get; set; }
        public bool? Cleared { get; set; }
        public string? Venuecode { get; set; }
        public bool? Vetted { get; set; }
        public string? Scriptno { get; set; }
        public string? Vetscore { get; set; }
        public string? Markerid { get; set; }
        public DateTime? Cleareddate { get; set; }
        public int? Query { get; set; }
        public int? Malpractice { get; set; }
        public DateTime? Vetteddate { get; set; }
        public bool? Processed { get; set; }
        public int? Reviewed { get; set; }
        public DateTime? Logdate { get; set; }
    }
}
