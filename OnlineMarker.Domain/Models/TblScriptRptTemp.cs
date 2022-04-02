using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class TblScriptRptTemp
    {
        public int Sid { get; set; }
        public string? Userid { get; set; }
        public string? Papercode { get; set; }
        public string? Scriptpageid { get; set; }
        public string? Pageno { get; set; }
        public string? Scriptpath { get; set; }
        public string? Scriptno { get; set; }
    }
}
