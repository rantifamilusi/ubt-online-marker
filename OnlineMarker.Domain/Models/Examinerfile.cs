using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class Examinerfile
    {
        public int LogId { get; set; }
        public string? Examtype { get; set; }
        public string? LoginId { get; set; }
        public string? Examinercode { get; set; }
        public string? Examinername { get; set; }
        public string? Schno { get; set; }
        public string? Schname { get; set; }
        public string? CandserialStart { get; set; }
        public string? CandserialEnd { get; set; }
        public string? Papercode { get; set; }
        public string? Papername { get; set; }
        public string? Subject { get; set; }
        public int? Totalscripts { get; set; }
        public bool? Clearedstatus { get; set; }
        public DateTime? Datelogged { get; set; }
        public string? Venuecode { get; set; }
        public string? Tdduser { get; set; }
    }
}
