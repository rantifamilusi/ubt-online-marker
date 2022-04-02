using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class TblAlloccentre
    {
        public int LogId { get; set; }
        public string? Examtype { get; set; }
        public string? Papercode { get; set; }
        public string? Examinercode { get; set; }
        public string? Centreno { get; set; }
        public int? Nextseedval { get; set; }
        public int? Totalalloc { get; set; }
        public bool? Availscript { get; set; }
        public DateTime? Datelogged { get; set; }
        public int? Vetscripttype { get; set; }
        public int? Markedallocs { get; set; }
        public int? Scriptstovet { get; set; }
        public int? Vettedscripts { get; set; }
    }
}
