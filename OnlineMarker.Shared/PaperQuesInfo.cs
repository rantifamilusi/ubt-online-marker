using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarker.Shared
{
    public class PaperQuesInfo
    {
       
        public string? Examtype { get; set; }
        public string? Papercode { get; set; }
        public string? Subjname { get; set; }
        public int Maxscore     { get; set; }
        public int Minscore     { get; set; }
        public int Totalquestions { get; set; }
        public string? Quesno    { get; set; }
        public int Qmaxscore    { get; set; }
        public int Qminscore    { get; set; }
        public int Qtartpage    { get; set; }
        public int Qndpage  { get; set; }
        public int Status   { get; set; }
        public string? Papertype         { get; set; }
        public string? Questype  { get; set; }
        public int Errormargin  { get; set; }
        public int Maxerraticcount  { get; set; }
        public int Sscoremax { get; set; }
        public decimal Errorpenalty1 { get; set; }
        public decimal Errorpenalty2 { get; set; }
        public decimal Errorpenalty3 { get; set; }
        public int Totalanswers { get; set; }
        public string? Responsepages { get; set; }
        public string? Qsection { get; set; }
        public int Sectionmax { get; set; }
        public int Submaxscore { get; set; }
        public bool Constscore { get; set; }
    }
}
