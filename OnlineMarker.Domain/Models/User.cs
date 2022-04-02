using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Login { get; set; } = null!;
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Emailaddr { get; set; }
        public string? Role { get; set; }
        public string? VenueCode { get; set; }
        public string? Examtype { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? EmployeeId { get; set; }
        public string? AccessStatus { get; set; }
        public string? CreatedBy { get; set; }
        public bool? Cpassword { get; set; }
    }
}
