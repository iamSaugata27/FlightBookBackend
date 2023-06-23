using FlightBook.DTOs;
using FlightBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBook.Services.FlightCreationService
{
    public interface IFlightServc
    {
        Task<List<FlightOperatorDTO>> GetFlightDetails();
        Task<List<FlightOperatorDTO>> AddFlightDetails(FlightOperatorDTO operatorDetails);
        Task<List<FlightOperatorDTO>> GetFlights(SearchFlightDTO searchQuery);
    }
}
