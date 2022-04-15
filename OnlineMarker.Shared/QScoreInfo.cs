using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarker.Shared
{
    public class QScoreInfo
    {
        

        public int scoreid { get; set; }
        public string scriptno { get; set; }
        public int markid { get; set; }
        public string examtype { get; set; }
        public string papercode { get; set; }
        public int quesno { get; set; }
        public decimal score { get; set; }
        public int numticks { get; set; }
        public string indexnumber { get; set; }
        public string examinercode { get; set; }
        public string vetterid { get; set; }
        public bool status { get; set; }
        public int vetted { get; set; }
        public bool seeded { get; set; }
        public bool seedstatus { get; set; }
        public bool mqa { get; set; }
        public decimal mecherror { get; set; }
        public int wordscount { get; set; }
        public string seedmaster { get; set; }
        public string markedpages { get; set; }
        public string marksposition { get; set; }
        public int review { get; set; }
    }

}
