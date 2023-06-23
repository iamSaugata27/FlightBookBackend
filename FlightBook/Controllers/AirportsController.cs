using FlightBook.DTOs;
using FlightBook.Services.AirportDetail;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlightBook.Controllers
{
    [ApiController]
    [Route("/travelhost/api/[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportServc _airportServc;
        public AirportsController(IAirportServc airportServc)
        {
            _airportServc = airportServc;
        }
        [HttpGet]
        public async Task<IActionResult> GetAirportDetails()
        {
            var airportDetails = await _airportServc.GetAirports();
            return Ok(airportDetails);
        }
        [HttpPost]
        public async Task<IActionResult> AddAirportDetail(AirportDetailsDTO airport)
        {
            var airportDetail = await _airportServc.AddAirport(airport);
            return Ok(airportDetail);
        }
    }
}
