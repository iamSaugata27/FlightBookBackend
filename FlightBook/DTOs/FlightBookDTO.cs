using System.Collections.Generic;

namespace FlightBook.DTOs
{
    public class FlightBookDTO
    {
        public string FlightId { get; set; }
        public List<PassengerDTO> Passengers { get; set; }
    }
}
