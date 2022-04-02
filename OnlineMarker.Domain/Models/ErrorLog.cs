using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class ErrorLog
    {
        public int LogId { get; set; }
        public string? ErrorLog1 { get; set; }
        public DateTime? DateLogged { get; set; }
    }
}
