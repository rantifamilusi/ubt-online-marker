using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class Examinerslist
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
        public DateTime? Dateloaded { get; set; }
        public string? AccessStatus { get; set; }
        public bool? Cpassword { get; set; }
        public string? Team { get; set; }
        public string? Clearedby { get; set; }
        public DateTime? Cleareddate { get; set; }
        public bool? Addedexaminer { get; set; }
        public bool? Gatecrasher { get; set; }
        public bool? Queried { get; set; }
        public string? Gsmnumber { get; set; }
        public bool? Seedmaster { get; set; }
        public bool? Allocstatus { get; set; }
    }
}
