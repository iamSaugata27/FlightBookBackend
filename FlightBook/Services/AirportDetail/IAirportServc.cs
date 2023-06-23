using FlightBook.DTOs;
using FlightBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBook.Services.AirportDetail
{
    public interface IAirportServc
    {
        Task<List<AirportDetails>> GetAirports();
        Task<AirportDetails> AddAirport(AirportDetailsDTO airport);
    }
}
