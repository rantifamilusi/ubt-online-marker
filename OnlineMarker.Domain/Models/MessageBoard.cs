using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class MessageBoard
    {
        public int Mid { get; set; }
        public string? Usertype { get; set; }
        public string? Userrole { get; set; }
        public string? Loginid { get; set; }
        public string? Typeid { get; set; }
        public int? Messageid { get; set; }
        public string? Sender { get; set; }
        public string? Sendername { get; set; }
        public string? Receiver { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime? Logdate { get; set; }
        public bool? Messagestatus { get; set; }
        public bool? Replyflag { get; set; }
    }
}
