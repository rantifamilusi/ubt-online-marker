using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class OperatorsInfo
    {
        public int Oid { get; set; }
        public string? Fullname { get; set; }
        public string? Emailaddress { get; set; }
        public string? Operatorid { get; set; }
        public bool? Accessstatus { get; set; }
        public string? Userlogin { get; set; }
        public bool? Uploading { get; set; }
        public DateTime? Lastupload { get; set; }
        public string? Postaladdress { get; set; }
        public string? Servername { get; set; }
        public bool? Approved { get; set; }
    }
}
