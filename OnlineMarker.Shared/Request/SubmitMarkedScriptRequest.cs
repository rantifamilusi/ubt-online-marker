using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarker.Shared.Request
{
    public class SubmitMarkedScriptRequest
    {
        public int markid { get; set; }
        public   string papercode { get; set; }
        public  string scriptno { get; set; }
        public decimal totalscore { get; set; }
        public bool vetobj { get; set; }
        public string vetteeid { get; set; }
        public int vetscripttype { get; set; }
        public bool seedmasterobj { get; set; }
        public bool seeded { get; set; }
        public List<QScoreInfo> seededqueslist { get; set; }
        public bool reviewobj { get; set; }
        public string markerid { get; set; }
        public int totalscriptsmarked { get; set; }
        public int seedinterval { get; set; }
        public string examtype { get; set; }
    }
}
