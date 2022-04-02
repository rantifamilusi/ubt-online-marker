using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class TblImageFile
    {
        public int Fid { get; set; }
        public string? Filename { get; set; }
        public byte[]? Imagebyte { get; set; }
        public string? Papercode { get; set; }
        public DateTime? Logdate { get; set; }
    }
}
