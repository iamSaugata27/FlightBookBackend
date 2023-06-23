using System;

namespace FlightBook.Models
{
    public class FlightOperator
    {
        public int Id { get; set; }
        public string FlightId { get; set; }
        public int Capacity { get; set; }
        public string OperatorName { get; set; }
        public string SourceCity { get; set; }
        public string DestCity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
