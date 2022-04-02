using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class ExamType
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Examyear { get; set; }
        public bool? Status { get; set; }
    }
}
