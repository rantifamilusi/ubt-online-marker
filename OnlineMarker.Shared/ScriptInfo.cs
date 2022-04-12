using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarker.Shared
{
    public class ScriptInfo
    {
        public int Markid { get; set; }
        public string? Examtype { get; set; }
        public string? Scriptno { get; set; }
        public string? Centreno { get; set; }
        public string? Schno { get; set; }
        public string? Schname { get; set; }

        public string? Indexnumber { get; set; }
        public string? indexno { get; set; }
        public string? Candname { get; set; }
        public string? Papercode { get; set; }
        public string? Mark { get; set; }
        public string? Examinercode { get; set; }
        public string? makerid { get; set; }
        public bool Seeded { get; set; }
        public string? Seedmaster { get; set; }
        public string? seededscript { get; set; }
        public int Totalmarked { get; set; }
        public int Queried { get; set; }
    }
}
