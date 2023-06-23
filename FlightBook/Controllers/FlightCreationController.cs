using FlightBook.Data;
using FlightBook.DTOs;
using FlightBook.Services.FlightCreationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FlightBook.Controllers
{
    [ApiController]
    [Route("/travelhost/api/[controller]")]
    public class FlightCreationController : ControllerBase
    {
        private readonly IFlightServc _flightServc;

        public FlightCreationController(IFlightServc flightServc)
        {
            _flightServc = flightServc;
        }

        [HttpGet]
        public async Task<ActionResult> Getallflightdetails()
        {
            var allflights = await _flightServc.GetFlightDetails();
            return Ok(allflights);
        }

        [HttpPost]
        public async Task<ActionResult> AddFlightDetails(FlightOperatorDTO operatorDetails)
        {
            var addedFlight = await _flightServc.AddFlightDetails(operatorDetails);
            return Ok(addedFlight);
        }
        [HttpGet("flight")]
        public async Task<ActionResult> GetFlights([FromQuery] SearchFlightDTO parmtr)
        {
            //var searchedFlight = new SearchFlightDTO { Src = parmtr.Src, Dest = parmtr.Dest, On = parmtr.On.Date };
            var searchedFlight = await _flightServc.GetFlights(parmtr);
            return Ok(searchedFlight);
        }
    }
}
