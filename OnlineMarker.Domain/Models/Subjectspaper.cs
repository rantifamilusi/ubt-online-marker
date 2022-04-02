using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class Subjectspaper
    {
        public int SubjectId { get; set; }
        public string? Examtype { get; set; }
        public string? Recordtype { get; set; }
        public string? Papercode { get; set; }
        public string? Subjname { get; set; }
        public int? Maxscore { get; set; }
        public int? Minscore { get; set; }
        public int? Totalquestions { get; set; }
        public string? Papertype { get; set; }
        public int? Sscoremax { get; set; }
        public decimal? Errorpenalty1 { get; set; }
        public decimal? Errorpenalty2 { get; set; }
        public decimal? Errorpenalty3 { get; set; }
        public int? Totalanswers { get; set; }
    }
}
