using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class PaperQuesControl
    {
        public string? Examtype { get; set; }
        public string? Papercode { get; set; }
        public string? Quesno { get; set; }
        public int? Qmaxscore { get; set; }
        public int? Qminscore { get; set; }
        public int? Startpage { get; set; }
        public int? Endpage { get; set; }
        public int? Status { get; set; }
        public string? Questype { get; set; }
        public string? Qsection { get; set; }
        public int? Sectionmax { get; set; }
        public int? Submaxscore { get; set; }
        public bool? Constscore { get; set; }
        public int? Sectionmin { get; set; }
    }
}
