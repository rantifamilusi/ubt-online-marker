using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarker.Shared.Request
{
    public class SaveMarkedScriptsRequest
    {
        public string examtype { get; set; }
        public string papercode { get; set; }
        public int markid { get; set; }
        public string scriptno { get; set; }
        public string quesno { get; set; }
        public decimal score { get; set; }
        public int tickno { get; set; }
        public List<SFilesInfo> sfiles { get; set; }
        public string markerid { get; set; }
        public string vetteeid { get; set; }
        public string indexno { get; set; }
        public bool vetobj { get; set; }
        public bool seedmasterobj { get; set; }
        public bool mqaobj { get; set; }
        public decimal mecherror { get; set; }
        public int wordscount { get; set; }
        public bool seeded { get; set; }
        public string seededscriptid { get; set; }
        public string markedpages { get; set; }
        public int malpractice { get; set; }
        public bool seededques { get; set; }
        public string marksposition { get; set; }
        public bool reviewobj { get; set; }
        public bool nullquesno { get; set; }
    }
}
