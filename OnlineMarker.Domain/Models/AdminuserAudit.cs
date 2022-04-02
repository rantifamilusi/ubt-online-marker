using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class AdminuserAudit
    {
        public int Logid { get; set; }
        public string? Examyear { get; set; }
        public string? Examtype { get; set; }
        public string? Papercode { get; set; }
        public int? Errormargin { get; set; }
        public int? Maxerraticcount { get; set; }
        public string? Userlogin { get; set; }
        public DateTime? Logdate { get; set; }
        public string? Responsepages { get; set; }
        public int? Practicescript { get; set; }
        public int? Minvet { get; set; }
        public int? Seedinterval { get; set; }
    }
}
