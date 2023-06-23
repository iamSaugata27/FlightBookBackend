using FlightBook.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightBook.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }
        public DbSet<FlightOperator> Operators { get; set; }
        public DbSet<AirportDetails> Airports { get; set; }
        public DbSet<Passengers> Passengers { get; set; }
    }
}
