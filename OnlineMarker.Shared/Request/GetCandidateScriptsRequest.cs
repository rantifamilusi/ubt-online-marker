using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarker.Shared.Request
{
    public class GetCandidateScriptsRequest
    {
        public string examtype { get; set; }
        public string papercode { get; set; }
        public string markerid { get; set; }
        public string vetteeid { get; set; }
        public bool seedmaster { get;set; }
        public bool vetobj { get;set;}
        public bool seedmasterobj { get;set; }
        public int scripttype { get; set; } 
        public int markedid { get; set; }
        public int totalscriptsmarked { get; set; }
        public bool unmarkedscript { get; set; }
        public string reloadscript { get; set; }
        public string indexnumber { get; set; }
        public bool seeded { get; set; }
        public string responsepages { get; set;}
        public bool reviewobj { get; set; }
        public bool reviewteam { get; set; }    
        public int seedinterval { get; set; }   
        public int practicescript { get; set; }
        public int minvet { get; set; }
        public int vetscripttype { get; set; }


    }
}
