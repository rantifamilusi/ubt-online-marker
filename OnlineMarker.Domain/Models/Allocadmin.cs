using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class Allocadmin
    {
        public int Logid { get; set; }
        public string? Examtype { get; set; }
        public string? Papercode { get; set; }
        public string? Markingstatus { get; set; }
        public int? Minallocation { get; set; }
        public string? Userlogin { get; set; }
        public int? Addallocation { get; set; }
    }
}
