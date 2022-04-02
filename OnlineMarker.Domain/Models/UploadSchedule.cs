using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class UploadSchedule
    {
        public string? Examtype { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string? Examyear { get; set; }
    }
}
