using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class TblAbsentCand
    {
        public int Sid { get; set; }
        public string? Papercode { get; set; }
        public string? Indexnumber { get; set; }
        public bool? Absent { get; set; }
        public string? Operatorid { get; set; }
        public DateTime? Dateuploaded { get; set; }
        public string? Examtype { get; set; }
    }
}
