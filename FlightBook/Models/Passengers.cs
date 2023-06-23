namespace FlightBook.Models
{
    public class Passengers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public FlightOperator Flight { get; set; }
    }
}
