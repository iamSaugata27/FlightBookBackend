using FlightBook.DTOs;
using FlightBook.Services.PassengerService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBook.Controllers
{
    [ApiController]
    [Route("/travelhost/api/[controller]")]
    public class FlightBookController : ControllerBase
    {
        private readonly IPassengerServc _passengerServc;

        public FlightBookController(IPassengerServc passengerServc)
        {
            _passengerServc = passengerServc;
        }
        [HttpPost]
        public async Task<IActionResult> AddPassengers([FromBody] FlightBookDTO bookingDetails)
        {
            var bookStatus = await _passengerServc.BookTicket(bookingDetails.FlightId,bookingDetails.Passengers);
            return Ok(bookStatus);
        }
    }
}
