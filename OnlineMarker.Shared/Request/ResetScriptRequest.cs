using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarker.Shared.Request
{
    public class ResetScriptRequest
    {
        public string papercode { get; set; }
        public string markerid { get; set; }
        public int markid { get; set; }
        public string scriptid { get; set; }
        public bool seeded { get; set; }
        public bool seedmasterobj { get; set; }
    }
}
