using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarker.Shared
{
   
    public class PapersInfo
    {
       

        public int Subjectid { get; set; }
        
        public string? Examtype { get; set; }
        public string? Papercode { get; set; }
        public string? Subjname { get; set; }
        
        public int Maxscore { get; set; }
        public int Minscore { get; set; }
        public int Totalquestions { get; set; }
    }
}
