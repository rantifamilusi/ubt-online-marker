using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class TblCentrestoAlloc
    {
        public int CentreId { get; set; }
        public string? Examtype { get; set; }
        public string? Papercode { get; set; }
        public string? Centreno { get; set; }
        public int? Numofcand { get; set; }
        public string? Allocid { get; set; }
    }
}
