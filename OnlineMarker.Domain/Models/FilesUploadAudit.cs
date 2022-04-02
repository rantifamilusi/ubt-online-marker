using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class FilesUploadAudit
    {
        public int Logid { get; set; }
        public string? Filetype { get; set; }
        public string? Filename { get; set; }
        public string? Userlogin { get; set; }
        public DateTime? Logdate { get; set; }
    }
}
