using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class ScriptsMaster
    {
        public int Sid { get; set; }
        public string? Papercode { get; set; }
        public string? Indexnumber { get; set; }
        public string? Scriptno { get; set; }
        public string? Operatorid { get; set; }
        public DateTime? Dateloaded { get; set; }
        public string? Examtype { get; set; }
        public string? Candname { get; set; }
        public string? Centre { get; set; }
        public bool? Sstatus { get; set; }
        public bool? Processed { get; set; }
        public string? Userlogin { get; set; }
    }
}
