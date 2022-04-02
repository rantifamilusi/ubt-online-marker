using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarker.Shared
{
    public class SeedInfo
    {
        public int Logid { get; set; }
        public string? Markingstatus { get; set; }
        public bool Accessstatus { get; set; }
        public bool Bulkalloc { get; set; }
        public string? Team { get; set; }
        public string? Venuecode { get; set; }
        public int Stotalmarked { get; set; }
        public int Nextseedval { get; set; }
        public int Totalalloc { get; set; }
        public bool Availscript { get; set; }
        public string? Alloccentre { get; set; }
        public int Minallocation { get; set; }
        public int Addallocation { get; set; }
        public bool Seedmaster { get; set; }
        public int Markedallocs { get; set; }
        public int Scriptstovet { get; set; }
        public int Vetscripttype { get; set; }
        public int Totalvetted { get; set; }
    }


}
