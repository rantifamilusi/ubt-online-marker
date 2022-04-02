using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class ScriptsMasterTemp
    {
        public int Sid { get; set; }
        public string? Papercode { get; set; }
        public string? Indexnumber { get; set; }
        public string? Scriptno { get; set; }
        public string? Uploadid { get; set; }
        public string? Operatorid { get; set; }
        public string? Examtype { get; set; }
    }
}
