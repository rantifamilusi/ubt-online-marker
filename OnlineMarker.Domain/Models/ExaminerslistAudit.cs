using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class ExaminerslistAudit
    {
        public int ExaminerId { get; set; }
        public string? Examtype { get; set; }
        public string? Examinernum { get; set; }
        public string? Examinername { get; set; }
        public string? Markingstatus { get; set; }
        public string? Password { get; set; }
        public string? Venuecode { get; set; }
        public string? Papercode { get; set; }
        public string? EmailAddr { get; set; }
        public bool? Attendance { get; set; }
        public string? Userid { get; set; }
        public int? ScriptsMarked { get; set; }
        public bool? ClearedStatus { get; set; }
        public DateTime? Logdate { get; set; }
        public string? AccessStatus { get; set; }
        public string? Updatetype { get; set; }
        public bool? Addedexaminer { get; set; }
        public bool? Gatecrasher { get; set; }
        public string? Gsmnumber { get; set; }
        public bool? Seedmaster { get; set; }
    }
}
