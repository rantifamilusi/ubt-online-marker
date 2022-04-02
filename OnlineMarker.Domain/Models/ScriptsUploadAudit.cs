using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class ScriptsUploadAudit
    {
        public int Uid { get; set; }
        public string? Operatorid { get; set; }
        public string? Papercode { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public int? Totalscripts { get; set; }
        public int? Totalimages { get; set; }
        public string? Sessionid { get; set; }
        public bool? Ready { get; set; }
        public bool? Completed { get; set; }
    }
}
