using System;

namespace FlightBook.DTOs
{
    public class SearchFlightDTO
    {
        public string Src { get; set; }
        public string Dest { get; set; }
        public DateTime On { get; set; }
    }
}
