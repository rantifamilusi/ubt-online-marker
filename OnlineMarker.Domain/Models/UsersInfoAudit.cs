using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class UsersInfoAudit
    {
        public int Auditid { get; set; }
        public string? Username { get; set; }
        public string? Userid { get; set; }
        public DateTime? Logdate { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Fullname { get; set; }
        public string? Emailaddr { get; set; }
        public string? Role { get; set; }
        public string? VenueCode { get; set; }
        public string? Examtype { get; set; }
        public string? EmployeeId { get; set; }
        public string? AccessStatus { get; set; }
        public string? Updatetype { get; set; }
    }
}
