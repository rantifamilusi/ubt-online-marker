using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class DepletedseedAudit
    {
        public int Logid { get; set; }
        public string? Examtype { get; set; }
        public string? Papercode { get; set; }
        public string? Examinercode { get; set; }
        public bool? Resolved { get; set; }
        public DateTime? Logdate { get; set; }
    }
}
