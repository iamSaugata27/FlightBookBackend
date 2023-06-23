using AutoMapper;
using FlightBook.Data;
using FlightBook.DTOs;
using FlightBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBook.Services.PassengerService
{
    public class PassengerServc : IPassengerServc
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _dBContext;

        public PassengerServc(IMapper mapper, ApplicationDBContext dBContext)
        {
            _mapper = mapper;
            _dBContext = dBContext;
        }
        public async Task<string> BookTicket(string flightID, List<PassengerDTO> passengers)
        {
            var flight=await _dBContext.Operators.FirstOrDefaultAsync(fl => fl.FlightId == flightID);
            if (flight.Capacity < passengers.Count)
                return $"Booking failed,Passengers limit exceeded";
            var bookedPassengers= passengers.Select(p => _mapper.Map<Passengers>(p));
            //bookedPassengers.Select(pn => pn.Flight = flight);
            flight.Capacity -= passengers.Count;
            var bookingTask = bookedPassengers.Select(async b =>
            {
                b.Flight = flight;
                await _dBContext.Passengers.AddAsync(b);
            });
            await Task.WhenAll(bookingTask);
            await _dBContext.SaveChangesAsync();
            return $"Booking succeeded for {passengers.Count} passengers";
        }
    }
}
