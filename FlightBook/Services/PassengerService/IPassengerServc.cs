using FlightBook.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBook.Services.PassengerService
{
    public interface IPassengerServc
    {
        Task<string> BookTicket(string flightID,List<PassengerDTO> passengers);
    }
}
