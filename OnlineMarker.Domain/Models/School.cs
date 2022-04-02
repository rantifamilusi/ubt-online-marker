using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class School
    {
        public int CentreId { get; set; }
        public string? Examtype { get; set; }
        public string? Recordtype { get; set; }
        public string? Centre { get; set; }
        public string? Centrename { get; set; }
        public string? Schno { get; set; }
        public string? Schname { get; set; }
    }
}
