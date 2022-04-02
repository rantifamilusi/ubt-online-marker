using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class CandidatesMaster
    {
        public int StudentId { get; set; }
        public string? Examtype { get; set; }
        public string? Recordtype { get; set; }
        public string? Centre { get; set; }
        public string? Indexnumber { get; set; }
        public string? Sex { get; set; }
        public string? Candname { get; set; }
        public string? Subjcode1 { get; set; }
        public string? Subjcode2 { get; set; }
        public string? Subjcode3 { get; set; }
        public string? Subjcode4 { get; set; }
        public string? Subjcode5 { get; set; }
        public string? Subjcode6 { get; set; }
        public string? Subjcode7 { get; set; }
        public string? Subjcode8 { get; set; }
        public string? Subjcode9 { get; set; }
        public string? Subjcode10 { get; set; }
        public string? Dob { get; set; }
        public string? Totalsubjects { get; set; }
        public string? Blind { get; set; }
        public string? Deaf { get; set; }
        public string? Dumb { get; set; }
        public string? Phychall { get; set; }
        public string? Indexrefno { get; set; }
        public string? Exammonyear { get; set; }
        public string? Grpawd { get; set; }
        public DateTime? Dateloaded { get; set; }
    }
}
