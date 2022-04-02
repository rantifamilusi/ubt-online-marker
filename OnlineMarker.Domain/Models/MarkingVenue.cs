using System;
using System.Collections.Generic;

namespace OnlineMarker.Domain.Models
{
    public partial class MarkingVenue
    {
        public int Venueid { get; set; }
        public string? VenueCode { get; set; }
        public string? Venuename { get; set; }
    }
}
